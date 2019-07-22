using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDControleDeEstoque.Models.ViewModels
{
    public class ProdutoViewModel
    {
        public int Prod_Id { get; set; }

        [Required(ErrorMessage = "Voce precisa digitar o nome do produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite a descrição do produto")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Especifique o preço"), DataType(DataType.Currency)]
        public decimal Preco { get; set; }

    }
}
