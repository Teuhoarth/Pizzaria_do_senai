namespace ProjetoEmTresCamadas.Pizzaria.DAO.Regras;

public interface IDao<T>
{
    //Task<T>obterRegistro(int id);//
    List<T> ObterRegistros();
    int CriarRegistro(T objetoVo);

    Task AtualizarRegistro(T objetoParaAtualizar);

    void Deletar(int ID);
}
