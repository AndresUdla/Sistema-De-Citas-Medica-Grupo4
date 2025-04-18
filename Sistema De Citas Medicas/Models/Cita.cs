using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_De_Citas_Medicas.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaHora { get; set; }

        [Required]
        [StringLength(20)]
        public string Estado { get; set; } = "Pendiente"; // Pendiente, Atendida, Cancelada

        [ForeignKey("Paciente")]
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        [ForeignKey("Medico")]
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
    }
}
