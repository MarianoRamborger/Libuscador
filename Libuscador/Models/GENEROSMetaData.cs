using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libuscador.Models
{
    public class GENEROSMetaData
    {
        [Required(ErrorMessage = "Falta el nombre del genero.")]

        public string Genero { get; set; }

        [Required(ErrorMessage = "Falta la descripcion.")]
        public string Descripcion { get; set; }
    }
}