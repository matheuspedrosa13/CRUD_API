namespace CrudOfertas.Api.Repositorios.Implementacoes;
using CrudOfertas.Api.Repositorios.DAOs;
using CrudOfertas.Api.Servicos;
using CrudOfertas.Api.Infraestrutura;
using CrudOfertas.Api.Repositorios.Interfaces;
using CrudOfertas.Api.Servicos.DTOs;

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

    public bool AtualizarOferta(int id, OfertaDAO ofertaDAO)
    {
        OfertaDatabase.ObterOfertas()[id - 1] = ofertaDAO;
        return true;
    }


    public bool DesativarOferta(int id)
    {
        OfertaDAO ofertaExistente = _ofertas.FirstOrDefault(o => o.Id == id)!;

        if (ofertaExistente != null)
        {
            if(ofertaExistente.Aprovada == false){
                return false;
            }
            ofertaExistente.Aprovada = false;
            return true;
        }
        return false;
    }

    public bool AtivarOferta(int id)
    {
        OfertaDAO ofertaExistente = _ofertas.FirstOrDefault(o => o.Id == id)!;

        if (ofertaExistente != null)
        {
            if(ofertaExistente.Aprovada == true){
                return false;
            }
            ofertaExistente.Aprovada = true;
            return true;
        }
        return false;
    }

}