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
    
    public partial class Email
    {
        public int EmailID { get; set; }
        public Nullable<int> FuncionarioID { get; set; }
        public string Conta { get; set; }
        public string Senha { get; set; }
        public string Finalidade { get; set; }
    
        public virtual Funcionario Funcionario { get; set; }
    }
}
