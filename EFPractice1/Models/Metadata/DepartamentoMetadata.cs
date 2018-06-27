using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFPractice1.Models.Metadata {
    public class DepartamentoMetadata {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(50, ErrorMessage = "Debe tener como máximo 50 caracteres")]
        public string Nombre { get; set; }

        public List<Empleado> Empleadoes { get; set; }
    }
}