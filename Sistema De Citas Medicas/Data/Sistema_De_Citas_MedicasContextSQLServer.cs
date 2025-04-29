using Microsoft.EntityFrameworkCore;
using Sistema_De_Citas_Medicas.Models;

public class Sistema_De_Citas_MedicasContextSQLServer : DbContext
{
    public Sistema_De_Citas_MedicasContextSQLServer(DbContextOptions<Sistema_De_Citas_MedicasContextSQLServer> options)
        : base(options)
    {
    }

    public DbSet<Medico> Medico { get; set; } = default!;
    public DbSet<Paciente> Paciente { get; set; } = default!;
    public DbSet<HistorialMedico> HistorialMedico { get; set; } = default!;
    public DbSet<Cita> Cita { get; set; } = default!;
    public DbSet<Usuario> Usuario { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cita>()
            .HasOne(c => c.Paciente)
            .WithMany()
            .HasForeignKey(c => c.PacienteId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Cita>()
            .HasOne(c => c.Medico)
            .WithMany()
            .HasForeignKey(c => c.MedicoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
