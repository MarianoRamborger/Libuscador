﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class DBLibros_MarianoRamborgerEntities : DbContext
{
    public DBLibros_MarianoRamborgerEntities()
        : base("name=DBLibros_MarianoRamborgerEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<AUTORES> AUTORES { get; set; }

    public virtual DbSet<EDITORIALES> EDITORIALES { get; set; }

    public virtual DbSet<GENEROS> GENEROS { get; set; }

    public virtual DbSet<LIBROS> LIBROS { get; set; }

    public virtual DbSet<LibrosxAutor> LibrosxAutor { get; set; }

    public virtual DbSet<LibrosxEditorial> LibrosxEditorial { get; set; }

    public virtual DbSet<LibrosxGenero> LibrosxGenero { get; set; }

}

}

