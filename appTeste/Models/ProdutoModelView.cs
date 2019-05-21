using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appTeste.Models
{
    public class ProdutoModelView
    {
        public virtual int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name ="Código")]
        public virtual string CodigoRef { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Descrição")]
        public virtual string Descricao { get; set; }

        [Display(Name = "Saldo em Estoque")]        
        public virtual double Saldo { get; set; }
    }
}