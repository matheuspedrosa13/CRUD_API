using CrudOfertas.Api.Controllers.Respostas;

namespace CrudOfertas.Api.Excecoes;

public class ErrosDeValidacaoException : Exception
{
    public List<ErrosDeValidacaoResposta> Erros {get;}

    public ErrosDeValidacaoException(List<ErrosDeValidacaoResposta> erros)
        => Erros = erros;
}
