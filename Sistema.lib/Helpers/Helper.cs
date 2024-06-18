using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
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
    }
}
