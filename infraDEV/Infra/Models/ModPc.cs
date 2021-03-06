//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ModPc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ModPc()
        {
            this.Pcs = new HashSet<Pc>();
        }
    
        public int ModPcID { get; set; }
        public Nullable<int> FabricanteID { get; set; }
        public string Processador { get; set; }
        public string Memoria { get; set; }
        public string Modelo { get; set; }
        public Nullable<int> FornecedorID { get; set; }
    
        public virtual Fabricante Fabricante { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pc> Pcs { get; set; }
    }
}
