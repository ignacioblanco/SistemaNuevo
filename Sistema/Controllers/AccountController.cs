using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Sistema.lib.Models;
using Sistema.lib.Entities;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Sistema.Controllers
{
    public class AccountController : Controller
    {
        #region Privado
        private const string Salt = "oiVYzUzDjJzRhPhI6aILwVGcudg9sp5Q8li6eWlPyYORTpDYTHYo5Rag3txxc6rh";
        #endregion

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
        private DatabaseContext db;

        public AccountController()
        {
            db = new DatabaseContext();
        }

        [HttpGet, AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password == model.RePassword)
                {
                    if (db.Cuentas.Any(u => u.Usuario == model.Username && !u.Baja))
                    {
                        TempData["IsError"] = "El nombre de usuario ya está en uso.";
                        return View(model);
                    }

                    // Hash la contraseña con la sal constante
                    var hashedPassword = HashPassword(model.Password);

                    Cuenta cuenta = new Cuenta
                    {
                        ID = Guid.NewGuid(),
                        Usuario = model.Username,
                        Mail = model.Mail,
                        Nombre = model.Nombre,
                        Apellido = model.Apellido,
                        Contraseña = hashedPassword,
                        Estado = Constantes.EstadosUser.SinAcciones,
                        Baja=false, 
                        PerfilID = Guid.NewGuid(),
                    };

                    db.Cuentas.Add(cuenta);
                    db.SaveChanges();


                    TempData["IsSuccess"] = "La cuenta se ha creado satisfactoriamente.";

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["IsError"] = "Las contraseñas no coinciden.";
                }
            }

            return View(model);
        }

        [HttpGet, AllowAnonymous]
        public ActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(new LoginModel());
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = db.Cuentas.Where(c => c.Usuario == model.Username && !c.Baja).FirstOrDefault();
                if (user != null && string.Compare(HashPassword(model.Password), user.Contraseña) == 0)
                {
                    var claims = new List<Claim>
                        {
                            new Claim(Constantes.CustomClaimIdentity.Nombre.ToString(), user.Nombre),
                            new Claim(Constantes.CustomClaimIdentity.Apellido.ToString(), user.Apellido),
                            new Claim(Constantes.CustomClaimIdentity.CuentaID.ToString(), user.ID.ToString()),
                            new Claim(ClaimTypes.Name, user.Usuario)
                        };
                    var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe
                    };

                    HttpContext.GetOwinContext().Authentication.SignIn(authProperties, identity);

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "El usuario o la contraseña son incorrectos.");

            }
            return View(model);
        }

        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet, AllowAnonymous]
        public ActionResult RecuperarPass(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(new RecuperarPasswordModel());
        }

        [HttpPost, AllowAnonymous]
        public ActionResult RecuperarPass(RecuperarPasswordModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = db.Cuentas.Where(c => c.Usuario == model.Username && !c.Baja).FirstOrDefault();
                if (user != null)
                {
                    var hashedPassword = HashPassword(model.NewPassword);
                    var hashedPassword2 = HashPassword(model.NewPassword2);

                    if (string.Compare(hashedPassword, hashedPassword2) != 0)
                    {
                        return View(model);
                        TempData["IsError"] = "Las contraseñas no son iguales";
                    }
                    else
                    {
                        user.Contraseña = hashedPassword;
                    }

                    db.SaveChanges();


                    TempData["IsSuccess"] = "La contraseña se ha actualizada satisfactoriamente.";

                    return RedirectToAction("Index", "Home");
                }

                TempData["IsError"] = "El usuario no esta registrado en el sistema";

            }
            return View(model);
        }


        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                // Combina la sal constante con la contraseña
                var saltedPassword = Salt + password;
                var bytes = System.Text.Encoding.UTF8.GetBytes(saltedPassword);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
