using System.ComponentModel.DataAnnotations;

namespace Sistema_De_Citas_Medicas.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Correo { get; set; }

        [Required]
        public string Contraseña { get; set; }

        [Required]
        public string Rol { get; set; }
    }


}
