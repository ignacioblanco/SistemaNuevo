using Sistema.lib.Entities;
using Sistema.lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema.Controllers
{
    public class AdministrarController : Controller
    {
        
        private DatabaseContext db = new DatabaseContext();


        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UsuarioABM()
        {

            if (!Helper.TienePermiso(Constantes.Opciones.AltaUsuarios, User.Identity.Name))
                return View("Index", "Home");

            ABMUsuariosModel model = new ABMUsuariosModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult UsuarioABM(ABMUsuariosModel model)
        {
           
            return View();
        }


    }
}