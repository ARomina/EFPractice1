using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFPractice1.Models.Metadata {
    public class EmpleadoMetadata {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Range(18, 90, ErrorMessage = "Ingrese una edad válida")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public int Sueldo { get; set; }

        public Departamento IdDepartamento{ get; set; }
    }
}