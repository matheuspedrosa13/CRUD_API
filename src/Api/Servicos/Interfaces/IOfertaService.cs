using CrudOfertas.Api.Repositorios.DAOs;
using CrudOfertas.Api.Servicos.DTOs;
namespace CrudOfertas.Api.Servicos.Interfaces;
public interface IOfertaService
{
    List<OfertaDAO> ObterTodasOfertas();
    OfertaDAO ObterOfertaPorId(int id);
    void AdicionarOferta(OfertaDTOPost oferta, int valorID);
    void AtualizarOferta(OfertaDAO oferta);
    void RemoverOferta(int id);
}