//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            this.PatientEvents = new HashSet<PatientEvents>();
            this.PatientHistory = new HashSet<PatientHistory>();
            this.Hospitalization = new HashSet<Hospitalization>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronomic { get; set; }
        public string PassportSerial { get; set; }
        public string PasspoerNumber { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string MedNum { get; set; }
        public Nullable<System.DateTime> MedDate { get; set; }
        public Nullable<System.DateTime> LastVisitDate { get; set; }
        public Nullable<System.DateTime> NextVisitDate { get; set; }
        public string InsuranceNum { get; set; }
        public System.DateTime InsuarnceEndDate { get; set; }
        public string InsuranceCompany { get; set; }
        public string JobName { get; set; }
        public string MedId { get; set; }
        public byte[] Photo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientEvents> PatientEvents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientHistory> PatientHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hospitalization> Hospitalization { get; set; }
    }
}
