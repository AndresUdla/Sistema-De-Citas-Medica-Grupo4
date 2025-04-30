using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_De_Citas_Medicas.Models
{
    public class Administrador
    {
        [Key]
        public int AdministradorId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "Debe ser un número de teléfono válido.")]
        public string Telefono { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
