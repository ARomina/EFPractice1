using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFPractice1.Models.Repositories {
    public class DepartamentoRepository {
        /*private EFPractice1Entities1 context = new EFPractice1Entities1();

        public List<Departamento> listarDepartamentos() {
            List<Departamento> listaDepartamentos = new List<Departamento>();
            return listaDepartamentos;
        }

        public Departamento buscarDepartamentoPorId(int id) {
            Departamento departamentoBuscado = null;
            departamentoBuscado = (from d in context.Departamentoes
                                   where d.Id == id
                                   select d).FirstOrDefault();
            return departamentoBuscado;
        }

        public void agregarEmpleado(Empleado empleado) {
            Departamento departamento = buscarDepartamentoPorId(1);
            departamento.Empleadoes.Add(empleado);
            context.SaveChanges();
        }*/

    }
}