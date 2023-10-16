using CrudOfertas.Api.Repositorios.DAOs;
using CrudOfertas.Api.Servicos.DTOs;

namespace CrudOfertas.Api.Repositorios.Interfaces;

public interface IOfertaRepository
{
    List<OfertaDAO> ObterTodasOfertas();
    OfertaDAO ObterOfertaPorId(int id);
    void AdicionarOferta(OfertaDAO oferta);
    bool DesativarOferta(int id);
    bool AtivarOferta(int id);
    bool AtualizarOferta(int id, OfertaDAO ofertaDAO);
    int TamanhoDatabase();
}