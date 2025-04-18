using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_De_Citas_Medicas.Models
{
    public class Medico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Especialidad { get; set; }

        [Required]
        public string Consultorio { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
