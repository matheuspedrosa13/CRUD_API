using CrudOfertas.Api.Servicos.DTOs;
using CrudOfertas.Api.Repositorios.Interfaces;

namespace CrudOfertas.Api.Servicos;
public class AdicionandoCoisasFixasEmOferta
{
    public static void AdicionadoPadraoOferta(OfertaDTOPost oferta)
    {
        oferta.DataCriacao = DateTime.Now;
        oferta.Aprovada = true;
    }
}