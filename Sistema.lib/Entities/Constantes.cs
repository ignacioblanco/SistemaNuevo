using RestSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Sistema.lib.Entities
{
    public class Constantes
    {


        public const string FiltroTodos = "TODO";

        public enum CustomClaimIdentity
        {
            Nombre,
            Apellido,
            AlumnoID,
            CuentaID
        }

        public struct EstadosUser
        {
            public const string Aceptado = "ACEPT";
            public const string Rechazado = "RECH";
            public const string SinAcciones = "SINAC";
        }

        public static List<ConstantesItem> EstadosUserTablaItem
        {
            get
            {
                List<ConstantesItem> tg = new List<ConstantesItem>();
                tg.Add(new ConstantesItem(EstadosUser.Aceptado, "Usuario aceptado"));
                tg.Add(new ConstantesItem(EstadosUser.Rechazado, "Usuario rechazado"));
                tg.Add(new ConstantesItem(EstadosUser.SinAcciones, "Usuario creado"));
                return tg;
            }
        }

        public static List<SelectListItem> EstadosUserSelectList
        {
            get
            {
                List<SelectListItem> l = new List<SelectListItem>();
                foreach (ConstantesItem t in Constantes.EstadosUserTablaItem)
                    l.Add(new SelectListItem { Value = t.Value, Text = t.Text });
                l = l.OrderBy(c => c.Text).ToList();
                l.Insert(0, new SelectListItem { Text = "TODOS", Value = Constantes.FiltroTodos });
                return l;
            }
        }
    }
}
