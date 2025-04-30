using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sistema_De_Citas_Medicas.Models;

namespace Sistema_De_Citas_Medicas.Data
{
    public class Sistema_De_Citas_MedicasContextSQLServer : DbContext
    {
        public Sistema_De_Citas_MedicasContextSQLServer(DbContextOptions<Sistema_De_Citas_MedicasContextSQLServer> options)
            : base(options)
        {
        }

        public DbSet<Administrador> Administrador { get; set; } = default!;
        public DbSet<Cita> Cita { get; set; } = default!;
        public DbSet<Horario> Horario { get; set; } = default!;
        public DbSet<Usuario> Usuario { get; set; } = default!;
        public DbSet<Medico> Medico { get; set; } = default!;
        public DbSet<Paciente> Paciente { get; set; } = default!;
    }
}
