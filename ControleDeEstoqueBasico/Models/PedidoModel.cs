using CRUDControleDeEstoque.Models.ViewModels;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace CRUDControleDeEstoque.Models
{
    public class PedidoModel
    {
        private static string connectionString = "Data Source=GUILHERME\\SQLEXPRESS;Initial Catalog=ControleDeEstoque;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<PedidoViewModel> ListarTodosPedidos()
        {
            using (var db = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Pedido";
                List<PedidoViewModel> pedidos = db.Query<PedidoViewModel>(sql).ToList();
                return pedidos;
            }
        }
        public static PedidoViewModel ListarPedidosPeloId(int id)
        {
            using (var db = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM Pedido Where Id = @id";
                PedidoViewModel pedido = db.QuerySingle<PedidoViewModel>(sql, new { id = id });
                return pedido;
            }
        }

        public static int AdicionarPedido(PedidoViewModel pedido)
        {
            int ret;
            using (var db = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO Pedido(Cliente_Id, Produto_Id, Quantidade) VALUES
                                (@Cliente_id, @Produto_Id, @Quantidade)";

                PedidoViewModel p = new PedidoViewModel
                {
                    Cliente_Id = pedido.Cliente_Id,
                    Produto_Id = pedido.Produto_Id,
                    Quantidade = pedido.Quantidade
                };
                ret = db.Execute(sql, p);
            }
            return ret;
        }

        public static int AtualizarPedido(PedidoViewModel pedido)
        {
            int ret;
            using (var db = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE Pedido SET Cliente_Id = @Cliente_Id, Produto_Id = @Produto_Id,
                                Quantidade = @Quantidade WHERE Id = @Id";
                PedidoViewModel p = new PedidoViewModel
                {
                    Id = pedido.Id,
                    Cliente_Id = pedido.Cliente_Id,
                    Produto_Id = pedido.Produto_Id,
                    Quantidade = pedido.Quantidade
                };

                ret = db.Execute(sql, p);
            }
            return ret;
        }

        public static int DeletarPedido(int id)
        {
            int ret;
            using (var db = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Pedido WHERE Id = @id";
                ret = db.Execute(sql, new { id = id });
            }
            return ret;
        }
    }
}
