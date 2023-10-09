namespace CrudOfertas.Api.Repositorios.Implementacoes;
using CrudOfertas.Api.Repositorios.DAOs;
using CrudOfertas.Api.Servicos.DTOs;
using CrudOfertas.Api.Infraestrutura;
using CrudOfertas.Api.Repositorios.Interfaces;
using System.Reflection;

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

        if (ofertaExistente == null)
        {
            throw new ArgumentException("Oferta não encontrada com o ID fornecido.");
        }

        if (!ofertaExistente.Aprovada)
        {
            throw new InvalidOperationException("Ofertas não aprovadas não podem ser alteradas.");
        }

        ofertaExistente.DataAtualizacao = DateTime.Now;

        foreach (var colunaAtualizada in colunasAtualizadas)
        {
            PropertyInfo propriedade = typeof(OfertaDAO).GetProperty(colunaAtualizada.Key)!;

            if (propriedade != null)
            {
                try
                {
                    Console.WriteLine("s");
                    Console.WriteLine(colunaAtualizada.Value);
                    Console.WriteLine(colunaAtualizada.GetType());
                    colunaAtualizada.ToString();
                    Console.WriteLine(colunaAtualizada.GetType());
                    Console.WriteLine(propriedade);
                    // object novoValor = Convert.ChangeType(colunaAtualizada.Value, propriedade.PropertyType);
                    // Console.WriteLine(novoValor);
                    // Console.WriteLine(novoValor.GetType);

                    propriedade.SetValue(ofertaExistente, colunaAtualizada.Value);
                }
                catch (InvalidCastException)
                {
                    throw new ArgumentException($"Valor inválido para a coluna '{colunaAtualizada.Key}': {colunaAtualizada.Value}");
                }
            }
            else
            {
                throw new ArgumentException($"A coluna '{colunaAtualizada.Key}' não existe na oferta.");
            }
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
