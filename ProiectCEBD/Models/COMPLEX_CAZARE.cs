//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class COMPLEX_CAZARE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COMPLEX_CAZARE()
        {
            this.UNITATI_DE_CAZARE = new HashSet<UNITATI_DE_CAZARE>();
        }
    
        public decimal IDCOMPLEXCAZARE { get; set; }
        public string DENUMIRE { get; set; }
        public string ADRESA { get; set; }
        public string EMAIL { get; set; }
        public string TELEFON { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UNITATI_DE_CAZARE> UNITATI_DE_CAZARE { get; set; }
    }
}
