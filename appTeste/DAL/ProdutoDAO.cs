using appTeste.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appTeste.DAL
{
    public class ProdutoDAO
    {
        private ISession session;

        public ProdutoDAO(ISession  s)
        {
            this.session = s;
        }

        public IList<Produto> List()
        {
            var list = session.QueryOver<Produto>().List();
            return list;
        }

        public IList<Produto> ListNativeSql()
        {
            const string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\appTeste\appTeste\App_Data\Database1.mdf;Integrated Security=True";
            using (SqlConnection conecxao = new SqlConnection(stringConnection))
            {
                using(SqlCommand comando = conecxao.CreateCommand())
                {
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = "Select * from Produto";

                    using(SqlDataReader leitor = comando.ExecuteReader())
                    {
                        IList<Produto> produtos = new List<Produto>();

                        while (leitor.Read())
                        {
                            produtos.Add(new Produto()
                            {
                                Id = Convert.ToInt32(leitor["Id"]),
                                CodigoRef = leitor["CodigoRef"].ToString(),
                                Descricao = leitor["Descricao "].ToString(),
                                Saldo  = Convert.ToDouble(leitor["Saldo"])
                            });
                        }

                        return produtos;
                    }
                }
            }
        }

        public void Update (Produto produto)
        {
            ITransaction tran = session.BeginTransaction();
            session.Merge(produto);
            tran.Commit();
        }
        public void Delete(Produto produto)
        {
            ITransaction tran = session.BeginTransaction();
            session.Delete(produto);
            tran.Commit();
        }
        public void Save(Produto produto)
        {
            ITransaction tran = session.BeginTransaction();
            session.Save(produto);
            tran.Commit();
        }
    }
}