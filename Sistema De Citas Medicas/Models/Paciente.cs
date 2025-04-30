using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_De_Citas_Medicas.Models
{
    public class Paciente
    {
        [Key]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no debe superar los 100 caracteres.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(100, ErrorMessage = "El apellido no debe superar los 100 caracteres.")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [StringLength(10, ErrorMessage = "La cédula debe tener 10 caracteres.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "La cédula debe contener solo números y tener 10 dígitos.")]
        public string Cedula { get; set; }

        // Nuevos atributos después de Cedula
        [Range(0, 150, ErrorMessage = "La edad debe ser un valor positivo y no mayor a 150 años.")]
        public int Edad { get; set; }

        [Range(0, 300, ErrorMessage = "La altura debe ser un valor positivo y no mayor a 300 cm.")]
        [Display(Name = "Altura (cm)")]
        public double? Altura { get; set; }

        [Range(0, 500, ErrorMessage = "El peso debe ser un valor positivo y no mayor a 500 kg.")]
        public double? Peso { get; set; }

        [StringLength(200, ErrorMessage = "La dirección no debe superar los 200 caracteres.")]
        public string Direccion { get; set; }

        [Phone(ErrorMessage = "El teléfono debe ser un número válido.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio.")]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        public ICollection<Cita> Citas { get; set; }

    }
}

