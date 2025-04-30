using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_De_Citas_Medicas.Models
{
    public class Medico
    {
        [Key]
        public int MedicoId { get; set; }

        [Required(ErrorMessage = "El nombre del médico es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no debe superar los 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La especialidad es obligatoria.")]
        [StringLength(100, ErrorMessage = "La especialidad no debe superar los 100 caracteres.")]
        public string Especialidad { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [StringLength(15, ErrorMessage = "El teléfono no debe superar los 15 caracteres.")]
        [Phone(ErrorMessage = "El teléfono debe ser válido.")]
        public string Telefono { get; set; }

        [StringLength(200, ErrorMessage = "La ubicación del consultorio no debe superar los 200 caracteres.")]
        public string UbicacionConsultorio { get; set; }

        [Required(ErrorMessage = "El ID del usuario es obligatorio.")]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }

        public ICollection<Horario> Horarios { get; set; }
        public ICollection<Cita> Citas { get; set; }
    }
}
