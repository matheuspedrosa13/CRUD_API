using CrudOfertas.Api.Repositorios.DAOs;
using CrudOfertas.Api.Repositorios.Interfaces;

namespace CrudOfertas.Api.Servicos;
public class AdicionandoCoisasFixasEmOferta
{
    public static void AdicionadoPadraoOferta(OfertaDAO oferta, IOfertaRepository ofertarepo, int id)
    {
        oferta.Id = id + 1;
        oferta.DataCriacao = DateTime.Now;
    }
}
