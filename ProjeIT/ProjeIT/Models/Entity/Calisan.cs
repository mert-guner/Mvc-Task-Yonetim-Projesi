//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjeIT.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Calisan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Calisan()
        {
            this.task = new HashSet<task>();
        }
    
        public int id { get; set; }
        public string kullanici_adi { get; set; }
        public string sifre { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<task> task { get; set; }
    }
}
