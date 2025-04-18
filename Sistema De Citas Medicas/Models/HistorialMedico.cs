﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_De_Citas_Medicas.Models
{
    public class HistorialMedico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Diagnostico { get; set; }

        [Required]
        public string Tratamiento { get; set; }

        public string Observaciones { get; set; }

        [ForeignKey("Cita")]
        public int CitaId { get; set; }
        public Cita Cita { get; set; }
    }
}
