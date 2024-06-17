using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.lib.Entities;

namespace Sistema.lib.Entities
{

    [Table("Cuenta")]
    public class Cuenta
    {
        public Guid ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Estado { get; set; }
        public Guid PerfilID { get; set; }
        public bool Baja { get; set; }
    }
}
