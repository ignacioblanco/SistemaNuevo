using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.lib.Models
{
    public class ABMUsuariosModel
    {

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El mail es obligatorio.")]
        [Display(Name = "Mail")]
        public string Mail { get; set; }

        [Display(Name = "Nombre de usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [Display(Name = "Rol")]
        public string PerfilID { get; set; }

        [Display(Name = "Estado")]
        public string EstadoUser { get; set; }

    }
}
