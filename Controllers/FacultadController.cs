using ApiExamenFinal.Data;
using ApiExamenFinal.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExamenFinal.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FacultadController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public FacultadController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IEnumerable<Facultad> Get()
        {
            return context.Facultades.ToList();
        }
        [HttpGet("{id}", Name = "facultadCreado")]
        public IActionResult GetById(int id)
        {
            var pais = context.Facultades.FirstOrDefault(x => x.Id == id);
            if (pais == null)
            {
                return NotFound();
            }
            return Ok(pais);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Facultad facultad)
        {
            if (ModelState.IsValid)
            {
                context.Facultades.Add(facultad);
                context.SaveChanges();
                return new CreatedAtRouteResult("facultadCreado",
                new { id = facultad.Id }, facultad);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Facultad facultad, int id)
        {
            if (facultad.Id != id)
            {
                return BadRequest();
            }
            context.Entry(facultad).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pais = context.Facultades.FirstOrDefault(x => x.Id == id);
            if (pais == null)
            {
                return NotFound();
            }
            context.Facultades.Remove(pais);
            context.SaveChanges();
            return Ok(pais);
        }
    }
}

