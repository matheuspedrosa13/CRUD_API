using CrudOfertas.Api.Repositorios.DAOs;
using CrudOfertas.Api.Servicos.DTOs;
namespace CrudOfertas.Api.Servicos.Interfaces;
using CrudOfertas.Api.Controllers.Requisicoes;

public interface IOfertaService
{
    List<OfertaDAO> ObterTodasOfertas();
    OfertaDAO ObterOfertaPorId(int id);
    void AdicionarOferta(OfertaDTOPost oferta);
    bool DesativarOferta(int id);
    bool AtivarOferta(int id);
    bool AtualizarOferta(int id, OfertaDTOPut ofertaDto);
    List<OfertaDTOGet> ofertaVerificada(List<OfertaDAO> todasOfertasDAO, ParametrosBuscaOferta parametrosBuscaOferta);
}