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
    
    public partial class STOCKER
    {
        public int NUMOUVR { get; set; }
        public int NUMDEP { get; set; }
        public Nullable<int> QTESTOCK { get; set; }
    
        public virtual DEPOT DEPOT { get; set; }
        public virtual OUVRAGE OUVRAGE { get; set; }
    }
}
