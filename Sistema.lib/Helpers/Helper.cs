using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Sistema.lib.Entities;

namespace Sistema.lib.Entities
{
    public class Helper
    {
        private DatabaseContext db;

        public Helper()
        {
            db = new DatabaseContext();
        }

        public static string ObtenerPerfilUsuario(string username)
        {

            using (var db = new DatabaseContext())
            {
                var user = db.Cuentas.Where(u => u.Usuario == username && !u.Baja).FirstOrDefault();
                if (user != null)
                {
                    var perfil = db.Perfiles.Where(p => p.ID == user.PerfilID).FirstOrDefault();
                    return perfil.Descripcion.ToString();
                }
            }
            return "";
        }

        public static bool TienePermiso(string Opcion, string Username) 
        {
            using (var db = new DatabaseContext())
            {
                var perfilID = db.Cuentas.Where(c => c.Usuario == Username && !c.Baja).Select(c => c.PerfilID).FirstOrDefault();
                var opcionID = db.Opciones.Where(o => o.Codigo == Opcion).Select(o => o.ID).FirstOrDefault();

                if (db.OpcionesPerfiles.Any(c => c.PerfilID == perfilID && c.OpcionID == opcionID))
                    return true;    

            }
            return false;
        }

        public static bool TienePerfil(string Perfil, string Username)
        {
            using (var db = new DatabaseContext())
            {
                var perfilID = db.Perfiles.Where(c => c.Codigo == Perfil ).Select(c => c.ID).FirstOrDefault();

                if (db.Cuentas.Any(c => c.PerfilID == perfilID && c.Usuario == Username && c.Baja))
                    return true;

            }
            return false;
        }
    }
}
