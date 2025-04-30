using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_De_Citas_Medicas.Models
{
    public class Cita
    {
        [Key]
        public int CitaId { get; set; }

        // Fecha y hora de la cita
        [Required]
        public DateTime FechaCita { get; set; }

        // Foreign Key hacia Paciente
        [Required]
        public int PacienteId { get; set; }

        [ForeignKey("PacienteId")]
        public Paciente Paciente { get; set; }

        // Foreign Key hacia Medico
        [Required]
        public int MedicoId { get; set; }

        [ForeignKey("MedicoId")]
        public Medico Medico { get; set; }

        // Foreign Key hacia Horario
        [Required]
        public int HorarioId { get; set; }

        [ForeignKey("HorarioId")]
        public Horario Horario { get; set; }

        // Fecha de creación de la cita
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
