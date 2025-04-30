using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_De_Citas_Medicas.Models
{
    public enum RolUsuario
    {
        Administrador,
        Medico,
        Paciente
    }

    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debe ser un correo válido.")]
        [StringLength(100)]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string Contrasena { get; set; }

        [Required(ErrorMessage = "El rol es obligatorio.")]
        public RolUsuario Rol { get; set; } // Ej: "Administrador", "Medico", "Paciente"

        // Relaciones uno a uno (opcional si no está asignado aún)
        public Administrador? Administrador { get; set; }
        public Medico? Medico { get; set; }
        public Paciente? Paciente { get; set; }
    }
}
