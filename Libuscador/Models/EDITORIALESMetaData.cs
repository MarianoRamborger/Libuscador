using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libuscador.Models
{
    public class EDITORIALESMetaData
    {
        [Required(ErrorMessage = "Falta el nombre de la editorial")]
        
        public string Nombre_editorial { get; set; }

        [Required(ErrorMessage = "Falta la pagina web.")]
        public string Pagina_web { get; set; }

        [Required(ErrorMessage = "Falta el pais")]
        public string Pais { get; set; }

     

    }
}