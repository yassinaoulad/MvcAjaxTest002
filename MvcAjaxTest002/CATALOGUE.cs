//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcAjaxTest002
{
    using System;
    using System.Collections.Generic;
    
    public partial class CATALOGUE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATALOGUE()
        {
            this.TARIFERs = new HashSet<TARIFER>();
        }
    
        public System.DateTime DATEDEB { get; set; }
        public Nullable<System.DateTime> DATEFIN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TARIFER> TARIFERs { get; set; }
    }
}
