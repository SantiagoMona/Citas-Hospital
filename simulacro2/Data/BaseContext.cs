using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using simulacro2.Models;

namespace simulacro2.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options){}
        public DbSet<Especialidad> Especialidades {get;set;}
        public DbSet<Paciente> Pacientes {get; set;}
         public DbSet<Medico> Medicos {get; set;}
         public DbSet<Cita> Citas {get;set;}
    }
}