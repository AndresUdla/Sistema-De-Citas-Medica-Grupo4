using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_De_Citas_Medicas.Models
{
    public class Horario
    {
        [Key]
        public int HorarioId { get; set; }

        [Required(ErrorMessage = "El día de la semana es obligatorio.")]
        public DayOfWeek Dia { get; set; }

        [Required(ErrorMessage = "La hora de inicio es obligatoria.")]
        [DataType(DataType.Time)]
        public TimeSpan HoraInicio { get; set; }

        [Required(ErrorMessage = "La hora de fin es obligatoria.")]
        [DataType(DataType.Time)]
        public TimeSpan HoraFin { get; set; }

        // Puedes eliminar esta línea si no necesitas la fecha de creación
        // public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El ID del médico es obligatorio.")]
        public int MedicoId { get; set; }

        [ForeignKey("MedicoId")]
        public Medico Medico { get; set; }
    }
}

