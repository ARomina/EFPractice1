using EFPractice1.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFPractice1.Models {

    [MetadataType(typeof(EmpleadoMetadata))]
    public partial class Empleado {
        public Empleado() {
        }

        public Empleado(string nombre, string apellido, int edad, int sueldo, Departamento departamento) {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;
            this.Sueldo = sueldo;
            this.Departamento = departamento;
        }

        public Empleado(Empleado empleado, Departamento departamento) {
            this.Nombre = empleado.Nombre;
            this.Apellido = empleado.Apellido;
            this.Edad = empleado.Edad;
            this.Sueldo = empleado.Sueldo;
            this.Departamento = departamento;
        }
    }
}