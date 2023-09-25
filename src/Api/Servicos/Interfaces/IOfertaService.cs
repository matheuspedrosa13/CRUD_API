using CrudOfertas.Api.Servicos.DTOs;

namespace CrudOfertas.Api.Servicos.Interfaces;

public interface IOfertaService
{
    List<OfertaDTO> ObterTodasOfertas();
    OfertaDTO ObterOfertaPorId(int id);
    void AdicionarOferta(OfertaDTO oferta);
    
}
