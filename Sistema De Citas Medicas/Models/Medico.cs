using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_De_Citas_Medicas.Models
{
    public class Medico
    {
        [Key]
        public int MedicoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Especialidad { get; set; }

        [Required]
        [StringLength(15)]
        public string Telefono { get; set; }

        [StringLength(200)]
        public string UbicacionConsultorio { get; set; }

        // Foreign Key hacia Usuario
        [Required]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        // Relaciones: Un médico puede tener muchos horarios
        public ICollection<Horario> Horarios { get; set; }

        // Relaciones: Un médico puede tener muchas citas
        public ICollection<Cita> Citas { get; set; }
    }
}
