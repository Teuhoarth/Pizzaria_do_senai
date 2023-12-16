﻿using ProjetoEmTresCamadas.Pizzaria.DAO;
using ProjetoEmTresCamadas.Pizzaria.DAO.ValueObjects;
using ProjetoEmTresCamadas.Pizzaria.RegraDeNegocio.Entidades;
using ProjetoEmTresCamadas.Pizzaria.RegraDeNegocio.Regras;

namespace ProjetoEmTresCamadas.Pizzaria.RegraDeNegocio.Serviços;

public class PizzaService :
    IAdicionar<Pizza>,
    IObter<Pizza>,
    IAtualizar<Pizza>,
    IDeletar<Pizza>
{
    private IPizzaDao PizzaDao { get; set; }

    public PizzaService(IPizzaDao pizzaDao)
    {
        PizzaDao = pizzaDao;
    }

    public PizzaService()
    {
        PizzaDao = new PizzaDao();
    }

    public Pizza Adicionar(Pizza objeto)
    {
        PizzaDao pizzaVo = objeto.ToPizzaVo();
        objeto.Id = PizzaDao.CriarRegistro(pizzaVo);
        return objeto;
    }

    public List<Pizza> ObterTodos()
    {
        List<Pizza> pizzas = new List<Pizza>();
        List<PizzaDao> pizzasBanco = PizzaDao.ObterRegistros();

        foreach (PizzaDao pizzaVo in pizzasBanco)
        {
            Pizza pizza = new Pizza()
            {
                Descricao = pizzaVo.Descricao,
                Sabor = pizzaVo.Sabor,
                TamanhoDePizza = (TamanhoDePizza)pizzaVo.TamanhoDePizza,
                Valor = pizzaVo.Valor,
                Id = pizzaVo.Id,
            };
            pizzas.Add(pizza);
        }
        return pizzas;
    }

    public async Task<Pizza> AtualizarAsync(Pizza objeto)
    {
        PizzaDao pizzaVo = objeto.ToPizzaVo();
        await PizzaDao.AtualizarRegistro(pizzaVo);

        objeto = ObterTodos().Find(pizza => pizza.Id.Equals(objeto.Id));

        return objeto;
    }

    public void Deletar(int obj)
    {
        PizzaDao.Deletar(obj);
    }
}
