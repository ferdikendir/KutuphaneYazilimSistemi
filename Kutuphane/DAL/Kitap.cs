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
    
    public partial class Kitap
    {
        public int kitapID { get; set; }
        public string baslik { get; set; }
        public Nullable<int> turID { get; set; }
        public Nullable<int> yazarID { get; set; }
        public Nullable<bool> durum { get; set; }
    
        public virtual Tur Tur { get; set; }
        public virtual Yazar Yazar { get; set; }
    }
}
