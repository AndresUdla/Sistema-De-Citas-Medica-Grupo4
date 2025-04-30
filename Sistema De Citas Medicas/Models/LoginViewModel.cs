using System.ComponentModel.DataAnnotations;

namespace Sistema_De_Citas_Medicas.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Rol { get; set; }
    }


}
