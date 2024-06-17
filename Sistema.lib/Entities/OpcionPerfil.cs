using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.lib.Entities
{

    [Table("OpcionPerfil")]
    public class OpcionPerfil
    {
        public Guid ID { get; set; }
        public Guid OpcionID { get; set; }
        public Guid PerfilID { get; set; }

    }
}
