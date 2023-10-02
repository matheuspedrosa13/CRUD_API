using CrudOfertas.Api.Servicos.DTOs;
using CrudOfertas.Api.Repositorios.DAOs;

namespace CrudOfertas.Api.Servicos
{
    public class ConverterDTOemDAOPost
    {
        public static OfertaDAO Converter(OfertaDTOPost ofertaDTO)
        {
            var ofertaDAO = new OfertaDAO
            {
                PorcentagemEmissao = ofertaDTO.PorcentagemEmissao,
                PorcentagemDistribuicao = ofertaDTO.PorcentagemDistribuicao,
                TaxaEmissao = ofertaDTO.TaxaEmissao,
                TaxaDistribuicao = ofertaDTO.TaxaDistribuicao,
                DataCarencia = ofertaDTO.DataCarencia,
                DataVencimento = ofertaDTO.DataVencimento,
                PrecoUnitario = ofertaDTO.PrecoUnitario,
                MinimoAplicacao = ofertaDTO.MinimoAplicacao,
                MaximoAplicacao = ofertaDTO.MaximoAplicacao,
                MinimoResgate = ofertaDTO.MinimoResgate,
                MaximoResgate = ofertaDTO.MaximoResgate,
                Estoque = ofertaDTO.Estoque,
                HorarioInicioNegociacao = ofertaDTO.HorarioInicioNegociacao,
                HorarioFimNegociacao = ofertaDTO.HorarioFimNegociacao,
                Liquidez = ofertaDTO.Liquidez,
                Indexador = ofertaDTO.Indexador,
                NomeEmissor = ofertaDTO.NomeEmissor,
                NomeTitulo = ofertaDTO.NomeTitulo,
                Risco = ofertaDTO.Risco,
                GarantidoPeloFGC = ofertaDTO.GarantidoPeloFGC,
                Descricao = ofertaDTO.Descricao,
                DataCriacao = ofertaDTO.DataCriacao,
                DataAtualizacao = ofertaDTO.DataAtualizacao,
                Aprovada = ofertaDTO.Aprovada
            };

            return ofertaDAO;
        }
    }
}
