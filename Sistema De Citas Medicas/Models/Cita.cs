using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_De_Citas_Medicas.Models
{
    public class Cita
    {
        [Key]
        public int CitaId { get; set; }

        [Required(ErrorMessage = "La fecha de la cita es obligatoria.")]
        [DataType(DataType.DateTime, ErrorMessage = "La fecha de la cita debe ser válida.")]
        public DateTime FechaCita { get; set; }

        [Required(ErrorMessage = "El ID del paciente es obligatorio.")]
        public int PacienteId { get; set; }

        [ForeignKey("PacienteId")]
        public Paciente? Paciente { get; set; }

        [Required(ErrorMessage = "El ID del médico es obligatorio.")]
        public int MedicoId { get; set; }

        [ForeignKey("MedicoId")]
        public Medico? Medico { get; set; }

        [Required(ErrorMessage = "El ID del horario es obligatorio.")]
        public int HorarioId { get; set; }

        [ForeignKey("HorarioId")]
        public Horario? Horario { get; set; }

        // Fecha en la que se creó la cita (no requerida al crear manualmente)
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
