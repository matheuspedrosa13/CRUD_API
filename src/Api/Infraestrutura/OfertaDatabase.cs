using CrudOfertas.Api.Repositorios.Enuns;
using CrudOfertas.Api.Repositorios.DAOs;
namespace CrudOfertas.Api.Infraestrutura;

public static class OfertaDatabase
{
    private static List<OfertaDAO> database = new List<OfertaDAO>
    {
        new OfertaDAO(){
            Id = 1,
            PorcentagemEmissao = 5.0m,
            PorcentagemDistribuicao = 2.0m,
            TaxaEmissao = 0.5m,
            TaxaDistribuicao = 0.2m,
            DataCarencia = DateTime.Parse("2023-09-30"),
            DataVencimento = DateTime.Parse("2024-09-30"),
            PrecoUnitario = 1000.0m,
            MinimoAplicacao = 500.0m,
            MaximoAplicacao = 5000.0m,
            MinimoResgate = 200.0m,
            MaximoResgate = 5000.0m,
            Estoque = 100,
            HorarioInicioNegociacao = DateTime.Parse("09:00:00"),
            HorarioFimNegociacao = DateTime.Parse("16:00:00"),
            Liquidez = true,
            Indexador = "CDI",
            NomeEmissor = "Emissor A",
            NomeTitulo = "CDB",
            Risco = RiscoOferta.BAIXO,
            GarantidoPeloFGC = true,
            Descricao = "Descrição da oferta 1",
            DataCriacao = DateTime.Parse("2023-09-29T10:46:44.6683519-03:00"),
            DataAtualizacao = DateTime.Parse("2023-09-29T10:46:44.6683519-03:00"),
            Aprovada = true
        },
        new OfertaDAO(){
            Id = 2,
            PorcentagemEmissao = 4.0m,
            PorcentagemDistribuicao = 1.5m,
            TaxaEmissao = 0.3m,
            TaxaDistribuicao = 0.1m,
            DataCarencia = DateTime.Parse("2023-10-15"),
            DataVencimento = DateTime.Parse("2024-10-15"),
            PrecoUnitario = 1500.0m,
            MinimoAplicacao = 1000.0m,
            MaximoAplicacao = 10000.0m,
            MinimoResgate = 300.0m,
            MaximoResgate = 8000.0m,
            Estoque = 50,
            HorarioInicioNegociacao = DateTime.Parse("10:00:00"),
            HorarioFimNegociacao = DateTime.Parse("17:00:00"),
            Liquidez = false,
            Indexador = "IPCA",
            NomeEmissor = "Emissor B",
            NomeTitulo = "LCI",
            Risco = RiscoOferta.MEDIO,
            GarantidoPeloFGC = false,
            Descricao = "Descrição da oferta 2",
            DataCriacao  = DateTime.Parse("2023-09-29T10:46:44.6683519-03:00"),
            DataAtualizacao  = DateTime.Parse("2023-09-29T10:46:44.6683519-03:00"),
            Aprovada  = true
        }
    };

    public static void AdicionarOferta(OfertaDAO oferta)
    {
        database.Add(oferta);
    }
    public static int TamanhoDatabase(){
        return database[0].Id;
    }
    public static List<OfertaDAO> ObterOfertas()
    {
        return database;
    }
}