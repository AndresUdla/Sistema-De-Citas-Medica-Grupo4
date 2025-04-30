using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_De_Citas_Medicas.Models
{
    public class Horario
    {
        [Key]
        public int HorarioId { get; set; }

        [Required]
        public DayOfWeek Dia { get; set; } // Día de la semana (lunes, martes, etc.)

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan HoraInicio { get; set; } // Hora de inicio del turno

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan HoraFin { get; set; } // Hora de fin del turno

        // Fecha de creación del horario
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Foreign Key hacia Medico
        [Required]
        public int MedicoId { get; set; }

        [ForeignKey("MedicoId")]
        public Medico Medico { get; set; }
    }
}
