using CrudOfertas.Api.Repositorios.DAOs;

namespace CrudOfertas.Api.Repositorios.Interfaces;
public interface IOfertaRepository
{
    List<OfertaDAO> ObterTodasOfertas();
    OfertaDAO ObterOfertaPorId(int id);
    void AdicionarOferta(OfertaDAO oferta);
    void AtualizarOferta(int id, Dictionary<string, object> colunasAtualizadas);
    void RemoverOferta(int id);
    int TamanhoDatabase();
}