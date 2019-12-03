using Libuscador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libuscador.Controllers
{
    public class AgregarController : Controller
    {
        private DBLibros_MarianoRamborgerEntities db = new DBLibros_MarianoRamborgerEntities();
        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CrearLibro()
        {
            return View();
        }




        [HttpPost] //MODELO
        [ValidateAntiForgeryToken]
        public ActionResult CrearLibro( [Bind(Include = "Lib_Id,ISBN,Titulo")]
             LIBROS nuevoLibro,
                IEnumerable<int> autores , IEnumerable<int> generos, int editorial)

        {
            var b = ModelState;
            if (ModelState.IsValid)
            {
                db.LIBROS.Add(nuevoLibro);
               
             

               foreach (int autID in autores)
                {
                LibrosxAutor nuevoLibAu= new LibrosxAutor();
                nuevoLibAu.Libro_Id = nuevoLibro.Lib_Id;
                nuevoLibAu.Autor_Id = autID;

                db.LibrosxAutor.Add(nuevoLibAu);
                }


                foreach (int genId in generos)
                {
                LibrosxGenero nuevoLibGen= new LibrosxGenero();
                nuevoLibGen.Libro_Id = nuevoLibro.Lib_Id;
                nuevoLibGen.Genero_Id = genId;

                db.LibrosxGenero.Add(nuevoLibGen);
                }

                LibrosxEditorial libXedi = new LibrosxEditorial();
                libXedi.Editorial_Id = editorial;
                db.LibrosxEditorial.Add(libXedi);


            db.SaveChanges();
           
                return RedirectToAction("CrearLibro");


            }

            else return Content("Hubo un error al intentar realizar su pedido. Por favor, revise sus datos e intente nuevamente.");
        }



        public ActionResult CrearAutor()
        {
          

            return View();

        }



        [HttpPost] //MODELO
        [ValidateAntiForgeryToken]
        public ActionResult CrearAutor([Bind(Include = "Aut_Nombre,Pais")]
             AUTORES nuevoAutor)

        {
            if (ModelState.IsValid)
            {


                db.AUTORES.Add(nuevoAutor);


                db.SaveChanges();

                return RedirectToAction("CrearAutor");
            }

            else return Content("Hubo un error al intentar realizar su pedido. Por favor, revise sus datos e intente nuevamente.");

        }

        public ActionResult CrearGenero()
        {


            return View();

        }



        [HttpPost] //MODELO
        [ValidateAntiForgeryToken]
        public ActionResult CrearGenero([Bind(Include = "Genero,Descripcion")]
             GENEROS nuevoGenero)

        {
            var a = ModelState;
            if (ModelState.IsValid)
            {
                db.GENEROS.Add(nuevoGenero);

                db.SaveChanges();

                return RedirectToAction("CrearGenero");

            }
            else
             
            return Content("Hubo un error al intentar realizar su pedido. Por favor, revise sus datos e intente nuevamente.");
        }


        public ActionResult CrearEditorial()
        {


            return View();

        }


        [HttpPost] //MODELO
        [ValidateAntiForgeryToken]
        public ActionResult CrearEditorial([Bind(Include = "Nombre_editorial,Pagina_web,Pais")]
             EDITORIALES nuevaEditorial)

        {
            if (ModelState.IsValid)
            {
                db.EDITORIALES.Add(nuevaEditorial);

                db.SaveChanges();

                return RedirectToAction("CrearEditorial");
            }
            else return Content("Hubo un error al intentar realizar su pedido. Por favor, revise sus datos e intente nuevamente.");
        }











    }
}