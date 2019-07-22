using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDControleDeEstoque.Models.ViewModels
{
    public class UsuarioViewModel
    {

        [Required]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required, Compare("Senha"), DataType(DataType.Password)]
        public string ConfirmarSenha { get; set; }
    }
}
