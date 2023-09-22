namespace CrudOfertas.Api.Servicos.DTOs;

public class OfertaDTO
{
    public decimal PorcentagemEmissao { get; set; }
    public decimal PorcentagemDistribuicao { get; set; }
    public decimal TaxaEmissao { get; set; }
    public decimal TaxaDistribuicao { get; set; }
    public DateTime DataCarencia { get; set; }
    public DateTime DataVencimento { get; set; }
    public decimal PrecoUnitario { get; set; }
    public decimal MinimoAplicacao { get; set; }
    public decimal MaximoAplicacao { get; set; }
    public decimal MinimoResgate { get; set; }
    public decimal MaximoResgate { get; set; }
    public int Estoque { get; set; }
    public DateTime  HorarioInicioNegociacao { get; set; }
    public DateTime HorarioFimNegociacao { get; set; }
    public bool Liquidez { get; set; }
    public string Indexador { get; set; }
    public string NomeEmissor { get; set; }
    public string NomeTitulo { get; set; }
    public string Risco { get; set; }
    public bool GarantidoPeloFGC { get; set; }
    public string Descricao{get;set;}
    public OfertaDTO(
        decimal porcentagemEmissao,
        decimal porcentagemDistribuicao,
        decimal taxaEmissao,
        decimal taxaDistribuicao,
        DateTime dataCarencia,
        DateTime dataVencimento,
        decimal precoUnitario,
        decimal minimoAplicacao,
        decimal maximoAplicacao,
        decimal minimoResgate,
        decimal maximoResgate,
        int estoque,
        DateTime horarioInicioNegociacao,
        DateTime horarioFimNegociacao,
        bool liquidez,
        string indexador,
        string nomeEmissor,
        string nomeTitulo,
        string risco,
        bool garantidoPeloFGC,
        string descricao)
    {
        PorcentagemEmissao = porcentagemEmissao;
        PorcentagemDistribuicao = porcentagemDistribuicao;
        TaxaEmissao = taxaEmissao;
        TaxaDistribuicao = taxaDistribuicao;
        DataCarencia = dataCarencia;
        DataVencimento = dataVencimento;
        PrecoUnitario = precoUnitario;
        MinimoAplicacao = minimoAplicacao;
        MaximoAplicacao = maximoAplicacao;
        MinimoResgate = minimoResgate;
        MaximoResgate = maximoResgate;
        Estoque = estoque;
        HorarioInicioNegociacao = horarioInicioNegociacao;
        HorarioFimNegociacao = horarioFimNegociacao;
        Liquidez = liquidez;
        Indexador = indexador;
        NomeEmissor = nomeEmissor;
        NomeTitulo = nomeTitulo;
        Risco = risco;
        GarantidoPeloFGC = garantidoPeloFGC;
        Descricao = descricao;
    }
}
