//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kutuphane.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tur
    {
        public Tur()
        {
            this.Kitaps = new HashSet<Kitap>();
        }
    
        public int turID { get; set; }
        public string tur1 { get; set; }
    
        public virtual ICollection<Kitap> Kitaps { get; set; }
    }
}
