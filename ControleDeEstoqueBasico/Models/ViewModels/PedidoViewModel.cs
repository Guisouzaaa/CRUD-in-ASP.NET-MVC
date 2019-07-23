using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDControleDeEstoque.Models.ViewModels
{
    public class PedidoViewModel
    {
        public int Id { get; set; }
        public int Cliente_Id { get; set; }
        public int Produto_Id { get; set; }
        public int Quantidade { get; set; }

    }
}
