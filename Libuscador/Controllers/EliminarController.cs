using Libuscador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libuscador.Controllers
{
    public class EliminarController : Controller
    {
        private DBLibros_MarianoRamborgerEntities db = new DBLibros_MarianoRamborgerEntities();

        public ActionResult EliminarLibro(int id)
        {
            LIBROS libro = db.LIBROS.Find(id);

            db.LIBROS.Remove(libro);

            db.SaveChanges();

            return Content("Libro eliminado satisfactoriamente");
        }




        // LOS METODOS A CONTINUACION SON INSEGUROS (POR EL ON-DELETE-CASCADE). 
        // VERSIONES SEGURAS PUEDEN SER IML
        public ActionResult EliminarAutor_PELIGRO(int id)
        {
            AUTORES autor = db.AUTORES.Find(id);

            db.AUTORES.Remove(autor);

            db.SaveChanges();

            return Content("Libro eliminado satisfactoriamente");
        }
        public ActionResult EliminarGenero_PELIGRO(int id)
        {
            GENEROS genero = db.GENEROS.Find(id);

            db.GENEROS.Remove(genero);

            db.SaveChanges();

            return Content("Genero eliminado satisfactoriamente");
        }
        public ActionResult EliminarEditorial_PELIGRO(int id)
        {
            EDITORIALES editorial = db.EDITORIALES.Find(id);

            db.EDITORIALES.Remove(editorial);

            db.SaveChanges();

            return Content("Editorial eliminado satisfactoriamente");
        }






    }
}