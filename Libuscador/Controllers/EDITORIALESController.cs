using Libuscador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libuscador.Controllers
{
    public class EDITORIALESController : Controller
    {

        private DBLibros_MarianoRamborgerEntities db = new DBLibros_MarianoRamborgerEntities();
        public ActionResult BuscarPorEditorial(string editorial)
        {
            List<dynamic> lst = new List<dynamic>();
            foreach (EDITORIALES Edi in db.EDITORIALES)
            {
                if (Edi.Nombre_editorial.ToLower().Contains(editorial))
                {

                    var FoundGenero = (from p in db.LIBROS
                                       join e in db.LibrosxAutor on p.Lib_Id equals e.Libro_Id
                                       join z in db.AUTORES on e.Autor_Id equals z.Aut_Id
                                       join c in db.LibrosxEditorial on p.Lib_Id equals c.Libro_Id
                                       join a in db.EDITORIALES on c.Editorial_Id equals a.Ed_Id
                                       join m in db.LibrosxGenero on p.Lib_Id equals m.Libro_Id
                                       join g in db.GENEROS on m.Genero_Id equals g.Gen_Id
                                       where c.Editorial_Id == Edi.Ed_Id

                                       select new
                                       {
                                           nombre = z.Aut_Nombre,
                                           titulo = p.Titulo,
                                           ISBN = p.ISBN,
                                           Editorial = a.Nombre_editorial,
                                           Id = Edi.Ed_Id,

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