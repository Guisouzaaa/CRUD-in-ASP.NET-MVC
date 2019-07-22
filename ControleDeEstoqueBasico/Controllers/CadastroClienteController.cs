using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDControleDeEstoque.Models;
using CRUDControleDeEstoque.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRUDControleDeEstoque.Controllers
{
    public class CadastroClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ListarTodosClientes()
        {
            return Json(ClienteModel.ListarTodosClientes());
        }

        public JsonResult ListarClientePeloId(int id)
        {
            return Json(ClienteModel.ListarClientePeloId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult CadastrarCliente(ClienteViewModel cliente)
        {
            return Json(ClienteModel.AdicionarCliente(cliente));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AtualizarCliente(ClienteViewModel cliente)
        {
            return Json(ClienteModel.AtualizarCliente(cliente));
        }

        [HttpPost]
        public JsonResult DeletarCliente(int id)
        {
            return Json(ClienteModel.DeletarCliente(id));
        }
    }
}