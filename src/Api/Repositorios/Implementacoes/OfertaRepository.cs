namespace CrudOfertas.Api.Repositorios.Implementacoes;
using CrudOfertas.Api.Repositorios.DAOs;
using CrudOfertas.Api.Servicos;
using CrudOfertas.Api.Infraestrutura;
using CrudOfertas.Api.Repositorios.Interfaces;

public class OfertaRepository  : IOfertaRepository
{
    private readonly List<OfertaDAO> _ofertas;

    public OfertaRepository()
    {
        _ofertas = OfertaDatabase.ObterOfertas();
    }

    public List<OfertaDAO> ObterTodasOfertas()
    {
        return _ofertas;
    }

    public OfertaDAO ObterOfertaPorId(int id)
    {
        return _ofertas.FirstOrDefault(o => o.Id == id)!;
    }

    public void AdicionarOferta(OfertaDAO oferta)
    {
 
        _ofertas.Add(oferta);
    }

    public int TamanhoDatabase(){
        int id = OfertaDatabase.TamanhoDatabase();
        return id;
    }

    public void AtualizarOferta(int id, Dictionary<string, object> colunasAtualizadas)
    {
        OfertaDAO ofertaExistente = _ofertas.FirstOrDefault(o => o.Id == id)!;

        if (ofertaExistente != null)
        {
            ValidarAtualizarOferta.ValidarOferta(ofertaExistente, colunasAtualizadas);
        }
    }


    public void RemoverOferta(int id)
    {
        OfertaDAO ofertaExistente = _ofertas.FirstOrDefault(o => o.Id == id)!;
        if (ofertaExistente != null)
        {
            ofertaExistente.Aprovada = false;
        }
    }
}