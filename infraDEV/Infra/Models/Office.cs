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
    
    public partial class Office
    {
        public int OfficeID { get; set; }
        public Nullable<int> ModSoftwareID { get; set; }
        public string Chave { get; set; }
        public bool Ativado { get; set; }
        public Nullable<int> FuncionarioID { get; set; }
    
        public virtual ModSoftware ModSoftware { get; set; }
        public virtual Funcionario Funcionario { get; set; }
    }
}
