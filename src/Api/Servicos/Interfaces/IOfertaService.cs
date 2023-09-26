using CrudOfertas.Api.Repositorios.DAOs;
namespace CrudOfertas.Api.Servicos.Interfaces;

public interface IOfertaService
{
    List<OfertaDAO> ObterTodasOfertas();
    OfertaDAO ObterOfertaPorId(int id);
    void AdicionarOferta(OfertaDAO oferta);
    void AtualizarOferta(OfertaDAO oferta);
    void RemoverOferta(int id);
    bool ValidarOferta(OfertaDAO oferta);
}