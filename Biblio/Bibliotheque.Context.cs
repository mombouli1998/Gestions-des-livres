﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Biblio
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BibliothequeEntities1 : DbContext
    {
        public BibliothequeEntities1()
            : base("name=BibliothequeEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Emprunts> Emprunts { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Livre> Livre { get; set; }
        public virtual DbSet<Membres> Membres { get; set; }
    }
}
