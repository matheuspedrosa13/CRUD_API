using CrudOfertas.Api.Repositorios.DAOs;
using CrudOfertas.Api.Servicos.Conversores;
using CrudOfertas.Api.Servicos.DTOs;

public class ConverterDTOPutParaDAO
{
    public static OfertaDAO Converter(OfertaDTOPut ofertaPut, OfertaDTOGet ofertaPassada)
    {
        var ofertaDAO = new OfertaDAO
        {
            Id = ofertaPassada.ID,
            PorcentagemEmissao = ofertaPut.PorcentagemEmissao,
            PorcentagemDistribuicao = ofertaPut.PorcentagemDistribuicao,
            TaxaEmissao = ofertaPut.TaxaEmissao,
            TaxaDistribuicao = ofertaPut.TaxaDistribuicao,
            DataCarencia = ofertaPut.DataCarencia,
            DataVencimento = ofertaPut.DataVencimento,
            PrecoUnitario = ofertaPut.PrecoUnitario,
            MinimoAplicacao = ofertaPut.MinimoAplicacao,
            MaximoAplicacao = ofertaPut.MaximoAplicacao,
            MinimoResgate = ofertaPut.MinimoResgate,
            MaximoResgate = ofertaPut.MaximoResgate,
            Estoque = ofertaPut.Estoque,
            HorarioInicioNegociacao = ofertaPut.HorarioInicioNegociacao,
            HorarioFimNegociacao = ofertaPut.HorarioFimNegociacao,
            Liquidez = ofertaPut.Liquidez,
            Indexador = ofertaPut.Indexador,
            NomeEmissor = ofertaPut.NomeEmissor,
            NomeTitulo = ofertaPut.NomeTitulo,
            Risco = ConverterStringParaEnumOfertasRisco.ConverterStringParaEnum(ofertaPut.Risco!),
            GarantidoPeloFGC = ofertaPut.GarantidoPeloFGC,
            Descricao = ofertaPut.Descricao,
            DataCriacao = ofertaPassada.DataCriacao,
            DataAtualizacao = DateTime.Now,
            Aprovada = ofertaPassada.Aprovada
        };

        return ofertaDAO;
    }
}
