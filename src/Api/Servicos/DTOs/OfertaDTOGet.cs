namespace CrudOfertas.Api.Servicos.DTOs
{
    public class OfertaDTO
    {
        public int ID { get; set; } // Nao vai aparecer
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
        public string Indexador { get; set; }
        public string NomeEmissor { get; set; }
        public string NomeTitulo { get; set; }
        public string Risco { get; set; }
        public bool GarantidoPeloFGC { get; set; }
        public string Descricao { get; set; }
        public string DescricaoOferta{ get; set; }
        public string DescricaoLiquidez{ get; set; }
        public string DescricaoRentabilidade{ get; set; }
        public string TipoProduto{ get; set; }
        public DateTime DataCriacao { get; set; } //Nao vai mostrar
        public DateTime DataAtualizacao { get; set; } //Nao vai mostrar
        public bool Aprovada { get; set; } //Nao vai mostrar
    }
}
