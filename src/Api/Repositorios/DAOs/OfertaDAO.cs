using CrudOfertas.Api.Repositorios.Enuns;
namespace CrudOfertas.Api.Repositorios.DAOs;

public class OfertaDAO
{
    public int Id { get; set; } // Nao vai aparecer
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
    public DateTime HorarioInicioNegociacao { get; set; }
    public DateTime HorarioFimNegociacao { get; set; }
    public bool Liquidez { get; set; }
    public string ?Indexador { get; set; }
    public string ?NomeEmissor { get; set; }
    public string ?NomeTitulo { get; set; }
    public RiscoOferta ?Risco { get; set; }
    public bool GarantidoPeloFGC { get; set; }
    public string ?Descricao { get; set; }
    public DateTime DataCriacao { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public bool Aprovada { get; set; }
}

