﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WsRDdigitalCAID
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CAIDEntities : DbContext
    {
        public CAIDEntities()
            : base("name=CAIDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<PAX00000> PAX00000 { get; set; }
        public virtual DbSet<SMX00100> SMX00100 { get; set; }
        public virtual DbSet<SMX00500> SMX00500 { get; set; }
        public virtual DbSet<PAX00001> PAX00001 { get; set; }
        public virtual DbSet<vCLASIFICADORES> vCLASIFICADORES { get; set; }
        public virtual DbSet<PAXESCOLARIDAD> PAXESCOLARIDAD { get; set; }
        public virtual DbSet<vPacienteRdDigital> vPacienteRdDigital { get; set; }
    }
}
