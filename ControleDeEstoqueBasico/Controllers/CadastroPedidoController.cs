using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDControleDeEstoque.Models;
using CRUDControleDeEstoque.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRUDControleDeEstoque.Controllers
{
    public class CadastroPedidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ListarTodosPedidos()
        {
            return Json(PedidoModel.ListarTodosPedidos());
        }

        public JsonResult ListarPedidoPeloId(int id)
        {
            return Json(PedidoModel.ListarPedidosPeloId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult CadastrarPedido(PedidoViewModel pedido)
        {
            return Json(PedidoModel.AdicionarPedido(pedido));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AtualizarPedido(PedidoViewModel pedido)
        {
            return Json(PedidoModel.AtualizarPedido(pedido));
        }

        [HttpPost]
        public JsonResult DeletarPedido(int id)
        {
            return Json(PedidoModel.DeletarPedido(id));
        }
    }
}