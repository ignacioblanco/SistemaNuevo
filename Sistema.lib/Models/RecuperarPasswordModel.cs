using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.lib.Models
{
    public class RecuperarPasswordModel
    {

        [Required]
        public string Username { get; set; }

        [Required]
        public string NewPassword { get; set; }


        [Required]
        public string NewPassword2 { get; set; }

    }
}
