using appTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appTeste.Factorys
{
    public static class ProdutoFactory
    {
        public static Produto BuildModel(ProdutoModelView modelView)
        {
            Produto produto = new Produto()
            {
                Id = modelView.Id,
                CodigoRef = modelView.CodigoRef,
                Descricao = modelView.Descricao,
                Saldo = modelView.Saldo
            };

            return produto;
        }

        public static ProdutoModelView BuildModelView(Produto model)
        {
            ProdutoModelView produtoModelView = new ProdutoModelView()
            {
                Id = model.Id,
                CodigoRef = model.CodigoRef,
                Descricao = model.Descricao,
                Saldo = model.Saldo
            };
            return produtoModelView;
        }

        public static IList<ProdutoModelView> BuildModelViewList(IList<Produto> listOfProdutco)
        {
            IList<ProdutoModelView> modelViewList = new List<ProdutoModelView>();
            foreach (var produto in listOfProdutco)
            {
                modelViewList.Add(BuildModelView(produto));
            }
            return modelViewList;
        }
    }
}