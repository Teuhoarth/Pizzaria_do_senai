using ProjetoEmTresCamadas.Pizzaria.DAO;
using ProjetoEmTresCamadas.Pizzaria.DAO.ValueObjects;

namespace ProjetoEmTresCamadas.Pizzaria.RegraDeNegocio.Entidades;


public class Pizza : EntidadeBase
{
    public string Sabor { get; set; }
    public TamanhoDePizza TamanhoDePizza { get; set; }
    public string Descricao { get; set; }
    public double Valor { get; set; }

    public Pizza()
    {
        Descricao = string.Empty;
        Valor = 0;
        TamanhoDePizza = TamanhoDePizza.Pequena;
        Sabor = string.Empty;
    }

    public override string ToString()
    {
        return $"Sua Pizza é de sabor {Sabor} e tamanho {TamanhoDePizza}";
    }

    public PizzaDao ToPizzaVo()
    {
        return new PizzaDao()
        {
            Id = Id,
            Descricao = Descricao,
            Sabor = Sabor,
            TamanhoDePizza = Convert.ToInt32(TamanhoDePizza),
            Valor = Valor
        };
    }
}
