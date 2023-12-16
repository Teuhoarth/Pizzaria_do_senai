using Microsoft.Data.Sqlite;
using ProjetoEmTresCamadas.Pizzaria.DAO.Regras;
using ProjetoEmTresCamadas.Pizzaria.DAO.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEmTresCamadas.Pizzaria.DAO
{
    public interface IClienteDao : IDao<ClienteDao>
    {

    }

    public class ClienteDao : BaseDao<ClienteDao>
    {
        private const string TABELA_CLIENTE_NOME = "TB_CLIENTE";

        private const string TABELA_CLIENTE = @$"CREATE TABLE IF NOT EXISTS {TABELA_CLIENTE_NOME}
                (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome VARCHAR(50) not null,
                    Telefone VARCHAR(100),
                    Idade varchar(100)
                )";

        private const string INSERIR_PIZZA = @$"
                INSERT INTO {TABELA_CLIENTE_NOME} (Nome, Telefone, Idade)
                VALUES (@Nome, @Telefone, @Idade)";

        private const string UPDATE_CLIENTE = @$"
    UPDATE {TABELA_CLIENTE_NOME}
    SET
        Nome = @Nome,
        Telefone = @Telefone,
        Idade = @Idade,
    WHERE
        ID = @Id";

        private const string DELETE_CLIENTE = @$"
    DELETE FROM {TABELA_CLIENTE_NOME}
    WHERE
        ID = @Id";

        private const string SELECT_CLIENTE = @$"SELECT * FROM {TABELA_CLIENTE_NOME}";



        public ClienteDao() : base(TABELA_CLIENTE, SELECT_CLIENTE, INSERIR_PIZZA, TABELA_CLIENTE_NOME, UPDATE_CLIENTE, DELETE_CLIENTE) { }

        protected override ClienteDao CriarInstancia(SqliteDataReader sqliteDataReader)
        {
            return new ClienteDao
            {
                Id = Convert.ToInt32(sqliteDataReader["Id"]),
                Nome = sqliteDataReader["Nome"].ToString(),
                Telefone = (sqliteDataReader["Telefone"].ToString()),
                Idade = Convert.ToInt32(sqliteDataReader["Idade"].ToString())
            };
        }
    }
}
