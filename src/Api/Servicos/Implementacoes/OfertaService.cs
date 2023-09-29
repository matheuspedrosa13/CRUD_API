using CrudOfertas.Api.Repositorios.Interfaces;
using CrudOfertas.Api.Servicos.Interfaces;
using CrudOfertas.Api.Repositorios.DAOs;

namespace CrudOfertas.Api.Servicos.Implementacos;
public class OfertaService : IOfertaService
{
    private readonly IOfertaRepository _ofertaRepository;

    public OfertaService(IOfertaRepository ofertaRepository)
    {
        _ofertaRepository = ofertaRepository;
    }

    public List<OfertaDAO> ObterTodasOfertas()
    {
        return _ofertaRepository.ObterTodasOfertas();
    }

    public OfertaDAO ObterOfertaPorId(int id)
    {
        return _ofertaRepository.ObterOfertaPorId(id);
    }

    public void AdicionarOferta(OfertaDAO oferta)
    {
        if (ValidarOferta(oferta))
        {
            _ofertaRepository.AdicionarOferta(oferta);
        }
        else
        {
            throw new ArgumentException("Oferta inválida. Verifique os dados.");
        }
    }

    public void AtualizarOferta(OfertaDAO oferta)
    {
        if (ValidarOferta(oferta))
        {
            _ofertaRepository.AtualizarOferta(oferta);
        }
        else
        {
            throw new ArgumentException("Oferta inválida. Verifique os dados.");
        }
    }

    public void RemoverOferta(int id)
    {
        _ofertaRepository.RemoverOferta(id);
    }

    public bool ValidarOferta(OfertaDAO oferta)
    {
        DateTime dataCriacao = oferta.DataCriacao;
        DateTime dataMinimaCarencia = dataCriacao.AddMonths(3);
        DateTime dataMinimaVencimento = dataCriacao.AddYears(5);
        if (oferta.DataCarencia < dataMinimaCarencia || oferta.DataVencimento < dataMinimaVencimento)
        {
            return false; 
        }
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
        if (!oferta.Liquidez || !oferta.GarantidoPeloFGC)
        {
            return false;
        }
        return true;
    }
}