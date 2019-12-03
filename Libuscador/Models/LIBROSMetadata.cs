using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libuscador.Models
{
    public class LIBROSMetadata
    {
        [Required(ErrorMessage = "Falta el ISBN")]

        public string ISBN { get; set; }

        [Required(ErrorMessage = "Falta el Titulo")]
        public string Titulo { get; set; }
    }
}