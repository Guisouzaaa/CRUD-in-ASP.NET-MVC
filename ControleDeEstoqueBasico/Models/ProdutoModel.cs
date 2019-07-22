using CRUDControleDeEstoque.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CRUDControleDeEstoque.Models
{
    public class ProdutoModel
    {
        private static string connectionString = "Data Source=GUILHERME\\SQLEXPRESS;Initial Catalog=ControleDeEstoque;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static ProdutoViewModel ListarProdutosPeloId(int id)
        {
            using (var db = new SqlConnection(connectionString))
            {
                string sql = "SELECT * From Produto WHERE Prod_Id = @prodId";
                ProdutoViewModel produto = db.QuerySingle<ProdutoViewModel>(sql, new { prodId = id });
                return produto;
            }
        }

        public static List<ProdutoViewModel> ListarTodosProdutos()
        {
            using (var db = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Produto";
                List<ProdutoViewModel> produtos = db.Query<ProdutoViewModel>(sql).ToList();
                return produtos;
            }
        }

        public static int AdicionarProdutos(ProdutoViewModel produto)
        {
            int ret;
            using (var db = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO Produto(Nome, Descricao, Preco) VALUES
                                (@Nome, @Descricao, @Preco)";

                ProdutoViewModel p = new ProdutoViewModel
                {
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco
                };
                ret = db.Execute(sql, p);
            }
            return ret;
        }

        public static int AtualizarProdutos(ProdutoViewModel produto)
        {
            int ret;
            using (var db = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE Produto SET Nome = @Nome, Descricao = @Descricao,
                                Preco = @Preco WHERE Prod_Id = @Prod_Id";
                ProdutoViewModel p = new ProdutoViewModel
                {
                    Prod_Id = produto.Prod_Id,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco
                };

                ret = db.Execute(sql, p);
            }
            return ret;
        }

        public static int DeletarProduto(int id)
        {
            int ret;
            using (var db = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Produto WHERE Prod_Id = @prodId";
                ret = db.Execute(sql, new { prodId = id });
            }
            return ret;
        }
    }
}
