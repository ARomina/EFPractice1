using EFPractice1.Models;
using EFPractice1.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFPractice1.Controllers
{
    public class HomeController : Controller {
        private EmpleadoRepository empleadoRepository = new EmpleadoRepository();
        private string mensajeError = null;

        //Variables para los tipos de mensajes a traer
        private static int LISTA_VACIA = 1;
        private static int NO_SE_PUDO_MODIFICAR = 2;
        private static int NO_SE_PUDO_ELIMINAR = 3;
        private static int NO_SE_PUDO_MODIFICAR_SUELDO = 4;
        private static int NO_SE_PUDO_CREAR = 5;

        // GET: Home
        public ActionResult Index() {
            List<Empleado> lista = empleadoRepository.listarEmpleados();
            if (!lista.Any()) {
                TempData["MensajeError"] = empleadoRepository.mostrarMensaje(LISTA_VACIA);
            }
            return View(lista);
        }

        //Vista Crear
        public ActionResult CrearEmpleado() {
            return View();
        }

        //Acción Crear
        public ActionResult CrearNuevoEmpleado([Bind(Include ="Nombre, Apellido, Edad, Sueldo")] Empleado empleado) {
            System.Diagnostics.Debug.Write("Nombre de empleado recibido - CrearNuevoEmpleado: " + empleado.Nombre);
            if (!empleadoRepository.crearEmpleado(empleado)) {
                TempData["MensajeError"] = empleadoRepository.mostrarMensaje(NO_SE_PUDO_CREAR);
            }
            return RedirectToAction("Index", "Home");
        }

        //Vista Modificar
        public ActionResult Modificar(Empleado empleado) {
            System.Diagnostics.Debug.Write("ID de empleado recibido - Modificar: " + empleado.Id);
            Empleado empleadoBuscado = empleadoRepository.buscarEmpleadoPorId(empleado.Id);
            return View(empleadoBuscado);
        }

        //Acción Modificar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarEmpleado([Bind(Include ="Id, Nombre, Apellido, Edad, Sueldo")]Empleado empleado) {
            System.Diagnostics.Debug.Write("ID de empleado recibido - ModificarEmpleado: " + empleado.Id);
            System.Diagnostics.Debug.Write("Nombre de empleado recibido - ModificarEmpleado: " + empleado.Nombre);
            Empleado empleadoModificado = empleadoRepository.modificarEmpleadoPorId(empleado.Id, empleado);
            return RedirectToAction("Modificar", "Home", empleadoModificado);
        }

        //Acción Eliminar
        public ActionResult Eliminar(Empleado empleado) {
            if (!empleadoRepository.eliminarEmpleadoPorId(empleado.Id)) {
                TempData["MensajeError"] = empleadoRepository.mostrarMensaje(NO_SE_PUDO_ELIMINAR);
            }
            return RedirectToAction("Index", "Home");
        }

        //Acción Aumentar
        public ActionResult AumentarSueldos() {
            empleadoRepository.aumentarSueldos();
            return RedirectToAction("Index", "Home");
        }
    }
}