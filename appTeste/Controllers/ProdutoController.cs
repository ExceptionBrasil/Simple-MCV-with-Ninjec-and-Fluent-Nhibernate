using appTeste.DAL;
using appTeste.Factorys;
using appTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appTeste.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutoDAO produtoDAO;

        public ProdutoController(ProdutoDAO p)
        {
            this.produtoDAO = p;
        }

        // GET: Produto
        public ActionResult Index()
        {
            var model= produtoDAO.List();
            var modelView = ProdutoFactory.BuildModelViewList(model);
            return View(modelView);
        }

        public ActionResult Incluir()
        {
            return View(new ProdutoModelView());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Incluir(ProdutoModelView modelView)
        {
            if (!ModelState.IsValid)
            {
                return View(modelView);
            }

            var produto = ProdutoFactory.BuildModel(modelView);

            produtoDAO.Save(produto);
            return Redirect("Index");
        }
    }
}