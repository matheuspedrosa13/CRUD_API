using CrudOfertas.Api.Repositorios.DAOs;
using CrudOfertas.Api.Repositorios.Interfaces;

namespace CrudOfertas.Api.Servicos;
public class AdicionandoCoisasFixasEmOferta
{
    public static void AdicionadoPadraoOferta(OfertaDAO oferta, IOfertaRepository ofertarepo, int id)
    {
        oferta.Id = id + 1;
        oferta.MinimoAplicacao = oferta.PrecoUnitario;
        oferta.MaximoAplicacao = oferta.PrecoUnitario * 300;
        oferta.MinimoResgate = oferta.PrecoUnitario * 10;
        oferta.MaximoResgate = oferta.PrecoUnitario * 300;
        oferta.DataCriacao = DateTime.Now;
        oferta.DataCarencia = DateTime.Now.AddDays(90);
        oferta.DataVencimento = DateTime.Now.AddDays(365);
        oferta.DataAtualizacao = DateTime.Now;
    }
}
