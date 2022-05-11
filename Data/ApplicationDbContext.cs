using ApiExamenFinal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExamenFinal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Facultad> Facultades { get; set; }
        public DbSet<ApiExamenFinal.Entities.Escuela> Escuela { get; set; }
        public DbSet<ApiExamenFinal.Entities.Carrera> Carrera { get; set; }
    }
}
