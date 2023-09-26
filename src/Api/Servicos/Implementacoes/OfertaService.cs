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
        // Implemente suas regras de validação aqui
        // Por exemplo, você pode verificar se os valores são válidos, se as datas estão corretas, etc.
        // Retorne true se a oferta for válida, caso contrário, retorne false.

        // Exemplo simples: Verificar se o preço unitário é maior que zero
        return oferta.PrecoUnitario > 0;
    }
}