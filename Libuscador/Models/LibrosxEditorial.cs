
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Libuscador.Models
{

using System;
    using System.Collections.Generic;
    
public partial class LibrosxEditorial
{

    public int Id { get; set; }

    public int Libro_Id { get; set; }

    public int Editorial_Id { get; set; }



    public virtual EDITORIALES EDITORIALES { get; set; }

    public virtual LIBROS LIBROS { get; set; }

}

}
