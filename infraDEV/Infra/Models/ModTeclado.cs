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
    
    public partial class ModTeclado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ModTeclado()
        {
            this.Tecladoes = new HashSet<Teclado>();
        }
    
        public int ModTecladoID { get; set; }
        public Nullable<int> FornecedorID { get; set; }
        public Nullable<int> FabricanteID { get; set; }
        public string Modelo { get; set; }
    
        public virtual Fabricante Fabricante { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teclado> Tecladoes { get; set; }
    }
}
