using ProjetoEmTresCamadas.Pizzaria.DAO.ValueObjects;
using ProjetoEmTresCamadas.Pizzaria.DAO;
using ProjetoEmTresCamadas.Pizzaria.RegraDeNegocio.Entidades;
using ProjetoEmTresCamadas.Pizzaria.RegraDeNegocio.Regras;

namespace ProjetoEmTresCamadas.Pizzaria.RegraDeNegocio.Serviços;

public class ClienteService : IObter<Cliente>, IAdicionar<Cliente>
{
    public Cliente Adicionar(Cliente objeto)
    {
        throw new NotImplementedException();
    }

    public void Adicionar(int ID)
    {
        throw new NotImplementedException();
    }

    public List<Cliente> ObterTodos()
    {
        throw new NotImplementedException();
    }

    public Cliente Adicionar(Pizza objeto)
    {
        ClienteDao clienteVo = objeto.ToPizzaVo();
        objeto.Id = ClienteDao.CriarRegistro(clienteVo);
        return objeto;
    }

    public List<Cliente> ObterTodos()
    {
        List<Cliente> clientes = new List<Cliente>();
        List<ClienteDao> clienteBanco = ClienteDao.ObterRegistros();

        foreach (ClienteDao clienteVo in clienteBanco)
        {
            Cliente cliente = new Cliente()
            {
                Nome = clienteVo.Nome,
                Telefone = clienteVo.Telefone,
                Idade = (TamanhoDePizza)clienteVo.Idade,
                Id = clienteVo.Id,
            };
            clientes.Add(cliente);
        }
        return clientes;
    }

    public async Task<Cliente> AtualizarAsync(Cliente objeto)
    {
        ClienteDao clienteVo = objeto.ToClienteVo();
        await ClienteDao.AtualizarRegistro(clienteVo);

        objeto = ObterTodos().Find(cliente => cliente.Id.Equals(objeto.Id));

        return objeto;
    }

    public void Deletar(int obj)
    {
        ClienteDao.Deletar(obj);
    }
}
