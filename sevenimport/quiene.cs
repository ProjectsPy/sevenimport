//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sevenimport
{
    using System;
    using System.Collections.Generic;
    
    public partial class quiene
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public int IdEmpresa { get; set; }
    
        public virtual empresa empresa { get; set; }
    }
}
