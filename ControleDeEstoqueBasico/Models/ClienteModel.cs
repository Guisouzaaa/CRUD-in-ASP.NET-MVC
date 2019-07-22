using CRUDControleDeEstoque.Models.ViewModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDControleDeEstoque.Models
{
    public class ClienteModel
    {
        private static string connectionString = "Data Source=GUILHERME\\SQLEXPRESS;Initial Catalog=ControleDeEstoque;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<ClienteViewModel> ListarTodosClientes()
        {
            using (var db = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM Cliente";
                List<ClienteViewModel> clientes = db.Query<ClienteViewModel>(sql).ToList();
                return clientes;
            }
        }

        public static ClienteViewModel ListarClientePeloId(int id)
        {
            using(var db = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM Cliente Where Cliente_Id = @ClienteId";
                ClienteViewModel cliente = db.QuerySingle<ClienteViewModel>(sql, new {ClienteId = id });
                return cliente;
            }
        }

        public static int AdicionarCliente(ClienteViewModel cliente)
        {
            int ret;
            using (var db = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO Cliente(Nome, Telefone, Email, CEP, Bairro, Cidade, Estado)
            VALUES (@Nome, @Telefone, @Email, @CEP, @Bairro, @Cidade, @Estado)";

                ret = db.Execute(sql, cliente);
            }
            return ret;
        }

        public static int AtualizarCliente(ClienteViewModel cliente)
        {
            int ret;
            using(var db = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE Cliente SET Nome = @Nome, Telefone = @Telefone, Email = @Email, CEP = @CEP,
                            Bairro = @Bairro, Cidade = @Cidade, Estado = @Estado WHERE Cliente_Id = @Cliente_Id";

                ret = db.Execute(sql, cliente);
            }
            return ret;
        }

        public static int DeletarCliente(int id)
        {
            int ret;
            using(var db = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Cliente Where Cliente_Id = @ClienteId";
                ret = db.Execute(sql, new { ClienteId = id });
            }
            return ret;
        }

    }
}
