﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProiectCEBD.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProiectEntities : DbContext
    {
        public ProiectEntities()
            : base("name=ProiectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CAMERE> CAMEREs { get; set; }
        public virtual DbSet<CLIENTI> CLIENTIs { get; set; }
        public virtual DbSet<COMPLEX_CAZARE> COMPLEX_CAZARE { get; set; }
        public virtual DbSet<FACILITATI> FACILITATIs { get; set; }
        public virtual DbSet<REVIEW> REVIEWs { get; set; }
        public virtual DbSet<REZERVARI> REZERVARIs { get; set; }
        public virtual DbSet<SERVICII_SUPLIMENTARE> SERVICII_SUPLIMENTARE { get; set; }
        public virtual DbSet<TIPURI_UNITATI_DE_CAZARE> TIPURI_UNITATI_DE_CAZARE { get; set; }
        public virtual DbSet<UNITATI_DE_CAZARE> UNITATI_DE_CAZARE { get; set; }
        public object CAMERE { get; internal set; }
    }
}
