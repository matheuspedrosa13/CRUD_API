using CrudOfertas.Api.Servicos.DTOs;
using CrudOfertas.Api.Repositorios.DAOs;
namespace CrudOfertas.Api.Servicos;
public class ConverterDAOemDTO
{
    public static OfertaDTOGet Converter(OfertaDAO ofertaDAO)
    {
        var ofertaDTO = new OfertaDTOGet
        {
            ID = ofertaDAO.Id,
            PorcentagemEmissao = ofertaDAO.PorcentagemEmissao,
            PorcentagemDistribuicao = ofertaDAO.PorcentagemDistribuicao,
            TaxaEmissao = ofertaDAO.TaxaEmissao,
            TaxaDistribuicao = ofertaDAO.TaxaDistribuicao,
            DataCarencia = ofertaDAO.DataCarencia,
            DataVencimento = ofertaDAO.DataVencimento,
            PrecoUnitario = ofertaDAO.PrecoUnitario,
            MinimoAplicacao = ofertaDAO.MinimoAplicacao,
            MaximoAplicacao = ofertaDAO.MaximoAplicacao,
            MinimoResgate = ofertaDAO.MinimoResgate,
            MaximoResgate = ofertaDAO.MaximoResgate,
            Estoque = ofertaDAO.Estoque,
            HorarioInicioNegociacao = ofertaDAO.HorarioInicioNegociacao,
            HorarioFimNegociacao = ofertaDAO.HorarioFimNegociacao,
            Liquidez = ofertaDAO.Liquidez,
            Indexador = ofertaDAO.Indexador,
            NomeEmissor = ofertaDAO.NomeEmissor,
            NomeTitulo = ofertaDAO.NomeTitulo,
            Risco = ofertaDAO.Risco.ToString(),
            GarantidoPeloFGC = ofertaDAO.GarantidoPeloFGC,
            Descricao = ofertaDAO.Descricao,
            DataCriacao = ofertaDAO.DataCriacao,
            DataAtualizacao = ofertaDAO.DataAtualizacao,
            Aprovada = ofertaDAO.Aprovada,
            
            // Campos customizados
            DescricaoOferta = $"{ofertaDAO.NomeTitulo} + ({ofertaDAO.Indexador})",
            DescricaoLiquidez = ofertaDAO.Liquidez ? "Diária" : "No vencimento",
            DescricaoRentabilidade = GetDescricaoRentabilidade(ofertaDAO),
            TipoProduto = GetTipoProduto(ofertaDAO.Indexador!)
        };

        return ofertaDTO;
    }

    private static string GetDescricaoRentabilidade(OfertaDAO ofertaDAO)
    {
        if (ofertaDAO.Indexador!.Equals("CDI", StringComparison.OrdinalIgnoreCase))
        {
            return $"{ofertaDAO.PorcentagemDistribuicao}% do CDI";
        }
        else if (ofertaDAO.Indexador.Equals("IPCA", StringComparison.OrdinalIgnoreCase))
        {
            return $"{ofertaDAO.Indexador} + {ofertaDAO.TaxaDistribuicao}% a.a.";
        }
        else if (ofertaDAO.Indexador.Equals("PRÉ", StringComparison.OrdinalIgnoreCase))
        {
            return $"{ofertaDAO.TaxaDistribuicao}% a.a.";
        }
        else
        {
            return "Tipo de rentabilidade não especificado";
        }
    }

    private static string GetTipoProduto(string indexador)
    {
        if (indexador.Equals("PRÉ", StringComparison.OrdinalIgnoreCase))
        {
            return "Pré-fixado";
        }
        else
        {
            return "Pós-fixado";
        }
    }
}