using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appTeste.Models
{
    public class ProdutoMapping:ClassMap<Produto>
    {
        public ProdutoMapping()
        {
            Id(x => x.Id);
            Map(x => x.CodigoRef);
            Map(x => x.Descricao);
            Map(x => x.Saldo);
    }
    }
}