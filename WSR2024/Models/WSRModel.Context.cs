﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSR2024.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WSR2024Entities : DbContext
    {
        public WSR2024Entities()
            : base("name=WSR2024Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<PatientEvents> PatientEvents { get; set; }
        public virtual DbSet<PatientHistory> PatientHistory { get; set; }
        public virtual DbSet<Conditions> Conditions { get; set; }
        public virtual DbSet<Hospitalization> Hospitalization { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
    }
}
