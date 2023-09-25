namespace CrudOfertas.Api.Servicos.DTOs
{
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
        public DateTime HorarioInicioNegociacao { get; set; }
        public DateTime HorarioFimNegociacao { get; set; }
        public bool Liquidez { get; set; }
        public string Indexador { get; set; }
        public string NomeEmissor { get; set; }
        public string NomeTitulo { get; set; }
        public string Risco { get; set; }
        public bool GarantidoPeloFGC { get; set; }
        public string Descricao { get; set; }

        public string DescricaoOferta => $"{NomeTitulo} ({Indexador})";

        public string DescricaoLiquidez => Liquidez ? "Diária" : "No vencimento";

        public string DescricaoRentabilidade
        {
            get
            {
                if (Indexador == "CDI")
                {
                    return $"{PorcentagemDistribuicao}% do CDI";
                }
                else if (Indexador == "IPCA")
                {
                    return $"{Indexador} + {TaxaDistribuicao}% a.a.";
                }
                else if (Indexador == "PRÉ")
                {
                    return $"{TaxaDistribuicao}% a.a.";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string TipoProduto
        {
            get
            {
                if (Indexador == "PRÉ")
                {
                    return "Pré-fixado";
                }
                else if (Indexador == "IPCA" || Indexador == "CDI")
                {
                    return "Pós-fixado";
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
