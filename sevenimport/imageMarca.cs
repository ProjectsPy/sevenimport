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
    
    public partial class imageMarca
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Imagen { get; set; }
        public Nullable<int> IdMarca { get; set; }
    
        public virtual marca marca { get; set; }
    }
}
