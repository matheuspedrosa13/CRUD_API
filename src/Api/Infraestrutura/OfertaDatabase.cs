namespace CrudOfertas.Api.Infraestrutura;
using CrudOfertas.Api.Repositorios.DAOs;
public static class OfertaDatabase
{
    private static List<OfertaDAO> database = new List<OfertaDAO>
    {
        new OfertaDAO
        (
            porcentagemEmissao: 5.0m,
            porcentagemDistribuicao: 2.0m,
            taxaEmissao: 0.5m,
            taxaDistribuicao: 0.2m,
            dataCarencia: DateTime.Parse("2023-09-30"),
            dataVencimento: DateTime.Parse("2024-09-30"),
            precoUnitario: 1000.0m,
            minimoAplicacao: 500.0m,
            maximoAplicacao: 5000.0m,
            minimoResgate: 200.0m,
            maximoResgate: 5000.0m,
            estoque: 100,
            horarioInicioNegociacao: DateTime.Parse("09:00:00"),
            horarioFimNegociacao: DateTime.Parse("16:00:00"),
            liquidez: true,
            indexador: "CDI",
            nomeEmissor: "Emissor A",
            nomeTitulo: "CDB",
            risco: "Baixo",
            garantidoPeloFGC: true,
            descricao: "Descrição da oferta 1"
        ),
        new OfertaDAO
        (
            porcentagemEmissao: 4.0m,
            porcentagemDistribuicao: 1.5m,
            taxaEmissao: 0.3m,
            taxaDistribuicao: 0.1m,
            dataCarencia: DateTime.Parse("2023-10-15"),
            dataVencimento: DateTime.Parse("2024-10-15"),
            precoUnitario: 1500.0m,
            minimoAplicacao: 1000.0m,
            maximoAplicacao: 10000.0m,
            minimoResgate: 300.0m,
            maximoResgate: 8000.0m,
            estoque: 50,
            horarioInicioNegociacao: DateTime.Parse("10:00:00"),
            horarioFimNegociacao: DateTime.Parse("17:00:00"),
            liquidez: false,
            indexador: "IPCA",
            nomeEmissor: "Emissor B",
            nomeTitulo: "LCI",
            risco: "Médio",
            garantidoPeloFGC: false,
            descricao: "Descrição da oferta 2"
        )
    };

    public static void AdicionarOferta(OfertaDAO oferta)
    {
        database.Add(oferta);
    }

    public static List<OfertaDAO> ObterOfertas()
    {
        return database;
    }
}














