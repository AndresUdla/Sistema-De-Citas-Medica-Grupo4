using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_De_Citas_Medicas.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        [Phone]
        public string Telefono { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
