using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.lib.Entities
{

    [Table("Opcion")]
    public class Opcion
    {
        public Guid ID { get; set; }

        public string Descripcion { get; set; }
    }
}
