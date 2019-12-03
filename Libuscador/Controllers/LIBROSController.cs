using Libuscador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libuscador.Controllers
{
    public class LIBROSController : Controller
    {

        private DBLibros_MarianoRamborgerEntities db = new DBLibros_MarianoRamborgerEntities();


        public ActionResult BuscarPorTitulo(string titulo)
        {
            List<dynamic> lst = new List<dynamic>();
            
          
            foreach (LIBROS Lib in db.LIBROS)
            {
                if (Lib.Titulo.ToLower().Contains(titulo))  
                {

                    var FoundLibro = (from p in db.LIBROS
                                      join e in db.LibrosxAutor on p.Lib_Id equals e.Libro_Id
                                      join z in db.AUTORES on e.Autor_Id equals z.Aut_Id
                                      join c in db.LibrosxEditorial on p.Lib_Id equals c.Libro_Id
                                      join a in db.EDITORIALES on c.Editorial_Id equals a.Ed_Id
                                      join m in db.LibrosxGenero on p.Lib_Id equals m.Libro_Id
                                      join g in db.GENEROS on m.Genero_Id equals g.Gen_Id
                                      where p.Lib_Id == Lib.Lib_Id

                                      select new
                                      {
                                          nombre = z.Aut_Nombre,
                                          titulo = Lib.Titulo,
                                          ISBN = Lib.ISBN,
                                          Editorial = a.Nombre_editorial,
                                          Genero = g.Genero,
                                          Id = Lib.Lib_Id,

                                      }).ToList() ;


                        lst.Add(FoundLibro);            
                   
                }
            }
            if (lst.Any()) { return Json(lst, JsonRequestBehavior.AllowGet); }
            else
                return Json("Lo sentimos. No hemos encontrado resultados.", JsonRequestBehavior.AllowGet);
        }


        public ActionResult BusquedaAnidada(string titulo, string genero, string autor, string editorial)
        {
            List<dynamic> lst = new List<dynamic>();

       

                foreach (LIBROS Lib in db.LIBROS)
                {



                    var FoundAll = (from p in db.LIBROS
                                    join e in db.LibrosxAutor on p.Lib_Id equals e.Libro_Id
                                    join z in db.AUTORES on e.Autor_Id equals z.Aut_Id
                                    join c in db.LibrosxEditorial on p.Lib_Id equals c.Libro_Id
                                    join a in db.EDITORIALES on c.Editorial_Id equals a.Ed_Id
                                    join m in db.LibrosxGenero on p.Lib_Id equals m.Libro_Id
                                    join g in db.GENEROS on m.Genero_Id equals g.Gen_Id
                                    where p.Lib_Id == Lib.Lib_Id

                                    select new
                                    {
                                        nombre = z.Aut_Nombre,
                                        titulo = Lib.Titulo,
                                        ISBN = Lib.ISBN,
                                        Editorial = a.Nombre_editorial,
                                        Genero = g.Genero,
                                        Id = Lib.Lib_Id,

                                    }).ToList();

                    foreach (var a in FoundAll)
                    {
                        if (titulo == "" || a.titulo.ToLower().Contains(titulo)) 
                        { 
                            if (genero == "" || a.Genero.ToLower().Contains(genero))
                            {
                                if (editorial == "" || a.Editorial.ToLower().Contains(editorial))
                                {
                                    if (autor == "" || a.nombre.ToLower().Contains(autor))
                                    {
                                        lst.Add(FoundAll);
                                    }
                                }
                            }
                        }    
                    }

                }
            
       

            if (lst.Any()) { return Json(lst, JsonRequestBehavior.AllowGet); }
            else
                return Json("Lo sentimos. No hemos encontrado resultados.", JsonRequestBehavior.AllowGet);
        }
    }
}







