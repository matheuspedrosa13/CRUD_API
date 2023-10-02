using CrudOfertas.Api.Servicos.DTOs;
namespace CrudOfertas.Api.Servico;
public class ValidarOferta
{
    public static bool Validar(OfertaDTOPost oferta)
    {
        if (oferta.PorcentagemEmissao <= 0 || oferta.PorcentagemDistribuicao <= 0 || oferta.TaxaEmissao <= 0 || oferta.TaxaDistribuicao <= 0
            || oferta.PrecoUnitario <= 0 || oferta.MinimoAplicacao <= 0 || oferta.MaximoAplicacao <= 0 || oferta.MinimoResgate <= 0 || oferta.MaximoResgate <= 0
            || oferta.Estoque < 0)
        {
            return false;
        }
        if (oferta.HorarioInicioNegociacao >= oferta.HorarioFimNegociacao)
        {
            return false; 
        }
        if (string.IsNullOrEmpty(oferta.Indexador) || string.IsNullOrEmpty(oferta.NomeEmissor) || string.IsNullOrEmpty(oferta.NomeTitulo) 
            || string.IsNullOrEmpty(oferta.Risco) || string.IsNullOrEmpty(oferta.Descricao))
        {
            return false;
        }
        return true;
    }
}