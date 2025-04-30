using System.ComponentModel.DataAnnotations;

namespace Sistema_De_Citas_Medicas.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Correo electrónico")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public string Rol { get; set; }  // paciente, medico o administrador
    }

}
