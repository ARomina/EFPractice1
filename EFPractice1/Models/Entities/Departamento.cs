using EFPractice1.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFPractice1.Models {

    [MetadataType(typeof(DepartamentoMetadata))]
    public partial class Departamento {
        public Departamento(string nombre) {
            this.Nombre = nombre;
        }
    }
}