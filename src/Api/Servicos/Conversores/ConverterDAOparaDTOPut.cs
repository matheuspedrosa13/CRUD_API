using CrudOfertas.Api.Repositorios.DAOs;
using CrudOfertas.Api.Servicos.Conversores;
using CrudOfertas.Api.Servicos.DTOs;

public class ConverterDAOemDTOPut
{
    public static OfertaDTOPut ConverterDTOGetParaPut(OfertaDAO ofertaGet)
    { 
        var ofertaPut = new OfertaDTOPut
        {
            PorcentagemEmissao = ofertaGet.PorcentagemEmissao,
            PorcentagemDistribuicao = ofertaGet.PorcentagemDistribuicao,
            TaxaEmissao = ofertaGet.TaxaEmissao,
            TaxaDistribuicao = ofertaGet.TaxaDistribuicao,
            DataCarencia = ofertaGet.DataCarencia,
            DataVencimento = ofertaGet.DataVencimento,
            PrecoUnitario = ofertaGet.PrecoUnitario,
            MinimoAplicacao = ofertaGet.MinimoAplicacao,
            MaximoAplicacao = ofertaGet.MaximoAplicacao,
            MinimoResgate = ofertaGet.MinimoResgate,
            MaximoResgate = ofertaGet.MaximoResgate,
            Estoque = ofertaGet.Estoque,
            HorarioInicioNegociacao = ofertaGet.HorarioInicioNegociacao,
            HorarioFimNegociacao = ofertaGet.HorarioFimNegociacao,
            Liquidez = ofertaGet.Liquidez,
            Indexador = ofertaGet.Indexador,
            NomeEmissor = ofertaGet.NomeEmissor,
            NomeTitulo = ofertaGet.NomeTitulo,
            Risco = ofertaGet.Risco.HasValue
                ? ConverterEnumParaStringOfertasRisco.ConverterEnumParaString(ofertaGet.Risco.Value)
                : null,
            GarantidoPeloFGC = ofertaGet.GarantidoPeloFGC,
            Descricao = ofertaGet.Descricao,
            DataCriacao = ofertaGet.DataCriacao,
            DataAtualizacao = ofertaGet.DataAtualizacao,
            Aprovada = ofertaGet.Aprovada
        };

        return ofertaPut;
    }
}
