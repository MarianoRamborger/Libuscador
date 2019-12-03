using Libuscador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libuscador.Controllers
{
    public class AutoresController : Controller
    {
        private DBLibros_MarianoRamborgerEntities db = new DBLibros_MarianoRamborgerEntities();
   
        public ActionResult BuscarPorAutor(string nombre)
        {
            List<dynamic> lst = new List<dynamic>(); 

            foreach (AUTORES Aut in db.AUTORES)
            {

                if (Aut.Aut_Nombre.ToLower().Contains(nombre))
                {

                    var FoundAutor = (from z in db.AUTORES
                                      join e in db.LibrosxAutor on z.Aut_Id equals e.Autor_Id
                                      join p in db.LIBROS on e.Libro_Id equals p.Lib_Id
                                      join c in db.LibrosxEditorial on p.Lib_Id equals c.Libro_Id
                                      join a in db.EDITORIALES on c.Editorial_Id equals a.Ed_Id
                                      join m in db.LibrosxGenero on p.Lib_Id equals m.Libro_Id
                                      join g in db.GENEROS on m.Genero_Id equals g.Gen_Id
                                      where e.Autor_Id == Aut.Aut_Id

                                      select new
                                      {
                                          nombre = z.Aut_Nombre,
                                          titulo = p.Titulo,
                                          ISBN = p.ISBN,
                                          Editorial = a.Nombre_editorial,
                                          Genero = g.Genero,
                                          Id = Aut.Aut_Id

                                      }).ToList();


                    lst.Add(FoundAutor);
                }
            }
            if (lst.Any()) { return Json(lst, JsonRequestBehavior.AllowGet); }

            else
                return Json("Sorry, no encontramos nada", JsonRequestBehavior.AllowGet);
        }


        public ActionResult BuscarAutor(string nombre)
        {

            List<object> lst = new List<object>();

            foreach (AUTORES Aut in db.AUTORES)
            {

                if (Aut.Aut_Nombre.ToLower().Contains(nombre))
                {

                    var FoundAutor = (from z in db.AUTORES

                                     where z.Aut_Id == Aut.Aut_Id
                                     select new
                                     {
                                         nombre = z.Aut_Nombre,
                                         pais = z.Pais            
                                         
                                     }).ToList();
                    lst.Add(FoundAutor);

                }

            }
            if (lst.Any()) { return Json(lst, JsonRequestBehavior.AllowGet); }

            else
                return Json("Sorry, no encontramos nada", JsonRequestBehavior.AllowGet);
        }

    }
}