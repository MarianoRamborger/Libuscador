using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libuscador.Models
{
    public class AUTORESMetaData
    {
        [Required(ErrorMessage = "Falta el nombre del autor.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Cuidado con la longitud")]
        public string Aut_Nombre { get; set; }

        [Required(ErrorMessage = "Falta el pais del autor.")]
        public string Pais { get; set; }


    }
}