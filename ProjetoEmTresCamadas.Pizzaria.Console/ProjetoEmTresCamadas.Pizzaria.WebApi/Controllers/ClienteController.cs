using Microsoft.AspNetCore.Mvc;
using ProjetoEmTresCamadas.Pizzaria.DAO;
using ProjetoEmTresCamadas.Pizzaria.RegraDeNegocio.Entidades;
using ProjetoEmTresCamadas.Pizzaria.RegraDeNegocio.Serviços;

namespace ProjetoEmTresCamadas.Pizzaria.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly ClienteService _adicionarCliente;

    public ClienteController (ClienteService adicionarCliente)
    {
        _adicionarCliente = adicionarCliente;
    }

    [HttpGet]
    public Cliente[] GetCliente()
    {
        List<Cliente> cliente = _adicionarCliente.ObterTodos();

        return cliente.ToArray();
    }

    [HttpPost]
    public Cliente AdicionarClienete(Cliente cliente)
    {
        cliente = _adicionarCliente.Adicionar(cliente);
        return cliente;
    }

    [HttpPut]
    public async Task<Pizza> Atualizarcliente(Cliente cliente)
    {
        return await _adicionarCliente.AtualizarAsync(cliente);
    }

    [HttpDelete]
    public void DeletarCliente(int ID)
    {
        _adicionarCliente.Deletar(ID);
    }

}
