using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDControleDeEstoque.Models;
using CRUDControleDeEstoque.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRUDControleDeEstoque.Controllers
{
    public class CadastroProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult ListarTodosProdutos()
        {
            return Json(ProdutoModel.ListarTodosProdutos());
        }

        public JsonResult ListarProdutoPeloId(int id)
        {
            return Json(ProdutoModel.ListarProdutosPeloId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult CadastrarProduto(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                return Json(ProdutoModel.AdicionarProdutos(produto));
            }
            return Json(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EditarProduto(ProdutoViewModel produto)
        {
            return Json(ProdutoModel.AtualizarProdutos(produto));
        }

        [HttpPost]
        public JsonResult DeletarProduto(int id)
        {
            return Json(ProdutoModel.DeletarProduto(id));
        }
    }
}