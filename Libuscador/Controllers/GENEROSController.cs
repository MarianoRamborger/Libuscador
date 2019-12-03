using Libuscador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libuscador.Controllers
{
    public class GENEROSController : Controller
    {
        private DBLibros_MarianoRamborgerEntities db = new DBLibros_MarianoRamborgerEntities();     

        public ActionResult BuscarPorGenero(string genero)
        {
            List<dynamic> lst = new List<dynamic>();
            foreach (GENEROS Gen in db.GENEROS)
            {
                if ( Gen.Genero.ToLower().Contains(genero))
                {

                    var FoundGenero = (from g in db.GENEROS
                                       join m in db.LibrosxGenero on g.Gen_Id equals m.Genero_Id
                                       join p in db.LIBROS on m.Libro_Id equals p.Lib_Id
                                       join e in db.LibrosxAutor on p.Lib_Id equals e.Libro_Id
                                       join z in db.AUTORES on e.Autor_Id equals z.Aut_Id
                                       join c in db.LibrosxEditorial on p.Lib_Id equals c.Libro_Id
                                       join a in db.EDITORIALES on c.Editorial_Id equals a.Ed_Id
                                       where m.Genero_Id == Gen.Gen_Id 

                                       select new
                                       {
                                           nombre = z.Aut_Nombre,
                                           titulo = p.Titulo,
                                           ISBN = p.ISBN,
                                           Editorial = a.Nombre_editorial,
                                           Genero = g.Genero,
                                           Id = Gen.Gen_Id,
                                            

                                       }).ToList();

                


                    lst.Add(FoundGenero);
                }
            }
            if (lst.Any()) { return Json(lst, JsonRequestBehavior.AllowGet); }
            else
                return Json("Sorry, no encontramos nada", JsonRequestBehavior.AllowGet);
        }



    }
}