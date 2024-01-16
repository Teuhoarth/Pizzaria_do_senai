using ProjetoEmTresCamadas.Pizzaria.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEmTresCamadas.Pizzaria.RegraDeNegocio.Entidades
{
    public class Cliente : EntidadeBase
    {
        public string Nome { get; set; }
        public string Telefone { get; internal set; }

        internal ClienteDao ToPizzaVo()
        {
            throw new NotImplementedException();
        }
    }
}
