using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sistema_De_Citas_Medicas.Models;

    public class Sistema_De_Citas_MedicasContextSQLServer : DbContext
    {
        public Sistema_De_Citas_MedicasContextSQLServer (DbContextOptions<Sistema_De_Citas_MedicasContextSQLServer> options)
            : base(options)
        {
        }

        public DbSet<Sistema_De_Citas_Medicas.Models.Usuario> Usuario { get; set; } = default!;

public DbSet<Sistema_De_Citas_Medicas.Models.Administrador> Administrador { get; set; } = default!;

public DbSet<Sistema_De_Citas_Medicas.Models.Medico> Medico { get; set; } = default!;

public DbSet<Sistema_De_Citas_Medicas.Models.Paciente> Paciente { get; set; } = default!;
    }
