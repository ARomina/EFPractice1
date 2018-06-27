using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace EFPractice1.Models.Repositories {
    public class EmpleadoRepository {
        private EFPractice1Entities1 context = new EFPractice1Entities1();

        //Variables para mensajes de error
        private static string MENSAJE_LISTA_VACIA = "No se encontraron empleados para listar";
        private static string MENSAJE_NO_SE_PUDO_MODIFICAR = "No se pudo modificar la información del empleado";
        private static string MENSAJE_NO_SE_PUDO_ELIMINAR = "No se pudo eliminar al empleado";
        private static string MENSAJE_NO_SE_PUDO_MODIFICAR_SUELDO = "No se pudo modificar la información de sueldos";
        private static string MENSAJE_NO_SE_PUDO_CREAR = "No se pudo crear el empleado";

        public List<Empleado> listarEmpleados() {
            List<Empleado> listaEmpleados = new List<Empleado>();
            listaEmpleados = context.Empleadoes.ToList();
            return listaEmpleados;
        }

        public Empleado buscarEmpleadoPorId(int empleadoId) {
            Empleado empleadoBuscado = null;
            empleadoBuscado = (from em in context.Empleadoes
                               where em.Id == empleadoId
                               select em).FirstOrDefault();
            return empleadoBuscado;
        }

        public Boolean crearEmpleado(Empleado empleado) {
            Departamento departamento = buscarDepartamentoPorId(1);
            Empleado empleadoNuevo = new Empleado(empleado, departamento);
            context.Empleadoes.Add(empleadoNuevo);
            //context.SaveChanges();

            try {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex) {
                foreach (var entityValidationErrors in ex.EntityValidationErrors) {
                    foreach (var validationError in entityValidationErrors.ValidationErrors) {
                        System.Diagnostics.Debug.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }

            empleadoNuevo = buscarEmpleado(empleado);
            agregarEmpleado(empleadoNuevo);

            return true;
        }

        //Esto esta hecho asi porque me olvide de poner algun campo tipo email o algo asi, 
        //que sea unico y no sea el id
        public Empleado buscarEmpleado(Empleado empleado) {
            Empleado empleadoBuscado = (from em in context.Empleadoes
                                        where em.Nombre == empleado.Nombre &&
                                        em.Apellido == empleado.Apellido &&
                                        em.Edad == empleado.Edad &&
                                        em.Sueldo == empleado.Sueldo
                                        select em).FirstOrDefault();
            return empleadoBuscado;
        }

        public Empleado modificarEmpleadoPorId(int empleadoId, Empleado empleadoEditado) {
            Empleado empleadoModificado = null;
            empleadoModificado = (from em in context.Empleadoes
                                  where em.Id == empleadoId
                                  select em).FirstOrDefault();
            empleadoModificado.Nombre = empleadoEditado.Nombre;
            empleadoModificado.Apellido = empleadoEditado.Apellido;
            empleadoModificado.Edad = empleadoEditado.Edad;
            empleadoModificado.Sueldo = empleadoEditado.Sueldo;
            empleadoModificado.Departamento = empleadoModificado.Departamento;

            context.SaveChanges();
            return empleadoModificado;
        }

        public Boolean eliminarEmpleadoPorId(int empleadoId) {
            Empleado empleadoAEliminar = null;
            empleadoAEliminar = (from em in context.Empleadoes
                                  where em.Id == empleadoId
                                  select em).FirstOrDefault();
            context.Empleadoes.Remove(empleadoAEliminar);
            context.SaveChanges();
            return true;
        }

        public void aumentarSueldos() {
            var empleados = (from em in context.Empleadoes
                             where em.Sueldo <= 20000 &&
                             em.Sueldo >= 10000
                             select em);
            foreach (Empleado em in empleados) { 
                em.Sueldo = em.Sueldo + 1000;
            }
            context.SaveChanges();
        }

        public string mostrarMensaje(int codigo) {
            String mensaje = "";
            switch (codigo) {
                case 1:
                    mensaje = MENSAJE_LISTA_VACIA;
                    break;
                case 2:
                    mensaje = MENSAJE_NO_SE_PUDO_MODIFICAR;
                    break;
                case 3:
                    mensaje = MENSAJE_NO_SE_PUDO_ELIMINAR;
                    break;
                case 4:
                    mensaje = MENSAJE_NO_SE_PUDO_MODIFICAR_SUELDO;
                    break;
                case 5:
                    mensaje = MENSAJE_NO_SE_PUDO_CREAR;
                    break;
                default:
                    System.Diagnostics.Debug.Write("No se pudo asignar el mensaje de error");
                    break;
            }
            return mensaje; 
        }

        //Departamento
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
        }
    }
}