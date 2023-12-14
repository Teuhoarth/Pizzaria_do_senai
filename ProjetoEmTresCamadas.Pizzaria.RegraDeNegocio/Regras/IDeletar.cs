using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEmTresCamadas.Pizzaria.RegraDeNegocio.Regras
{
    public interface IDeletar<T>
    {
        void Deletar(int obj);
    }
}
