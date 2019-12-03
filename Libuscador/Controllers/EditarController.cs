using Libuscador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libuscador.Controllers
{
    public class EditarController : Controller
    {
        private DBLibros_MarianoRamborgerEntities db = new DBLibros_MarianoRamborgerEntities();


        public ActionResult EditarLibro(int id)
        {
            if (ModelState.IsValid)
            {
                LIBROS libro = db.LIBROS.Find(id);

                List<int> AutoresId = new List<int>();
                List<int> GenerosId = new List<int>();
                List<int> EditorialesId = new List<int>();

                foreach (LibrosxAutor union in db.LibrosxAutor)
                {

                    if (union.Libro_Id == id)
                    {
                        int unionFound = union.Autor_Id;
                        AutoresId.Add(unionFound);
                    }
                }
                foreach (LibrosxGenero union in db.LibrosxGenero)
                {

                    if (union.Libro_Id == id)
                    {
                        int unionGenero = union.Genero_Id;
                        GenerosId.Add(unionGenero);
                    }
                }
                foreach (LibrosxEditorial union in db.LibrosxEditorial)
                {

                    if (union.Libro_Id == id)
                    {
                        int unionEditorial = union.Editorial_Id;
                        EditorialesId.Add(unionEditorial);
                    }
                }


                ViewBag.AutoresId = AutoresId;
                ViewBag.GenerosId = GenerosId;
                ViewBag.EditorialesId = EditorialesId;

                return View("../Agregar/CrearLibro", libro);


            }
            else return null;
        }

        [HttpPost]
        public ActionResult EditarLibro(LIBROS Libro, IEnumerable<int> autores, IEnumerable<int> generos, int editorial)
        {
            if (ModelState.IsValid)
            {
                db.LIBROS.Add(Libro);


                foreach (LibrosxAutor union in db.LibrosxAutor)
                {
                    if (Libro.Lib_Id == union.Libro_Id)
                    {
                        db.LibrosxAutor.Remove(union);
                    }
                }
                foreach (LibrosxEditorial union in db.LibrosxEditorial)
                    if (Libro.Lib_Id == union.Libro_Id)
                    {
                        db.LibrosxEditorial.Remove(union);
                    }
                foreach (LibrosxGenero union in db.LibrosxGenero)
                    if (Libro.Lib_Id == union.Libro_Id)
                    {
                        db.LibrosxGenero.Remove(union);
                    }

                foreach (int autID in autores)
                {
                    LibrosxAutor nuevoLibAu = new LibrosxAutor();
                    nuevoLibAu.Libro_Id = Libro.Lib_Id;
                    nuevoLibAu.Autor_Id = autID;

                    db.LibrosxAutor.Add(nuevoLibAu);
                }


                foreach (int genId in generos)
                {
                    LibrosxGenero nuevoLibGen = new LibrosxGenero();
                    nuevoLibGen.Libro_Id = Libro.Lib_Id;
                    nuevoLibGen.Genero_Id = genId;

                    db.LibrosxGenero.Add(nuevoLibGen);
                }


                LibrosxEditorial libXedi = new LibrosxEditorial();
                libXedi.Editorial_Id = editorial;
                libXedi.Libro_Id = Libro.Lib_Id;
                db.LibrosxEditorial.Add(libXedi);

                db.Entry(Libro).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

                return Content("Libro editado exitosamente");
            }
            else return null;

        }


        public ActionResult EditarAutor(int id)
        {
            AUTORES Autor = db.AUTORES.Find(id);

            return View("../Agregar/CrearAutor", Autor);

        }


        [HttpPost]
        public ActionResult EditarAutor(AUTORES autor)
        {
            if (ModelState.IsValid)
            {
                db.AUTORES.Add(autor);

                db.Entry(autor).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

                return Content("Autor editado satisfactoriamente");

            }
            else return null;
        }


        public ActionResult EditarEditorial(int id)
        {
            EDITORIALES Editorial = db.EDITORIALES.Find(id);

            return View("../Agregar/CrearEditorial", Editorial);

        }


        [HttpPost]
        public ActionResult EditarEditorial(EDITORIALES editorial)
        {
            db.EDITORIALES.Add(editorial);

            db.Entry(editorial).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();

            return Content("Editorial editado satisfactoriamente");


        }

        public ActionResult EditarGenero(int id)
        {
            GENEROS genero = db.GENEROS.Find(id);

            return View("../Agregar/CrearGenero", genero);

        }


        [HttpPost]
        public ActionResult EditarGenero(GENEROS generos)
        {

            if (ModelState.IsValid)
            {
                db.GENEROS.Add(generos);


                db.Entry(generos).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

                return Content("Editorial editado satisfactoriamente");

            }
            else return null;
        }











    }
}