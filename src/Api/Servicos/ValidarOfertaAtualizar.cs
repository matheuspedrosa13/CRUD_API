using CrudOfertas.Api.Controllers.Respostas;
using CrudOfertas.Api.Excecoes;
using CrudOfertas.Api.Servicos.DTOs;

namespace CrudOfertas.Api.Servicos;

public class ValidarOfertaAtualizar
{
    public static void ValidarComExcecao(OfertaDTOPut ofertaDTO)
    {
        List<ErrosDeValidacaoResposta> erros = new List<ErrosDeValidacaoResposta>();
        ValidarSeMaximoResgateMaiorQueZero(erros, ofertaDTO.MaximoResgate, ofertaDTO);
        ValidarSeEstoqueMaiorQueZero(erros, ofertaDTO.Estoque);
        ValidarSePorcentagemEmissaoMaiorQueZero(erros, ofertaDTO.PorcentagemEmissao);
        ValidarSePorcentagemDistribuicaoMaiorQueZero(erros, ofertaDTO.PorcentagemDistribuicao);
        ValidarSeTaxaEmissaoMaiorQueZero(erros, ofertaDTO.TaxaEmissao);
        ValidarSeTaxaDistribuicaoMaiorQueZero(erros, ofertaDTO.TaxaDistribuicao);
        ValidarSePrecoUnitarioMaiorQueZero(erros, ofertaDTO.PrecoUnitario);
        ValidarSeMinimoAplicacaoMaiorQueZero(erros, ofertaDTO.MinimoAplicacao);
        ValidarSeMaximoAplicacaoMaiorQueZero(erros, ofertaDTO.MaximoAplicacao, ofertaDTO);
        ValidarSeMinimoResgateMaiorQueZero(erros, ofertaDTO.MinimoResgate);
        ValidarHorarioDeNegociacao(erros, ofertaDTO.HorarioFimNegociacao, ofertaDTO);
        ValidarDataCarencia(erros, ofertaDTO.DataCarencia, ofertaDTO);
        ValidarIndexador(erros, ofertaDTO.Indexador ?? string.Empty);
        ValidarNomeEmissor(erros, ofertaDTO.NomeEmissor ?? string.Empty);
        ValidarNomeTitulo(erros, ofertaDTO.NomeTitulo ?? string.Empty);
        ValidarRisco(erros, ofertaDTO.Risco ?? string.Empty);
        ValidarDescricao(erros, ofertaDTO.Descricao ?? string.Empty);

        if (erros.Count > 0)
        {
            throw new ErrosDeValidacaoException(erros);
        }
    }

    private static void ValidarIndexador(List<ErrosDeValidacaoResposta> erros, string indexador)
    {
        if (string.IsNullOrEmpty(indexador))
        {
            erros.Add(new ErrosDeValidacaoResposta()
            {
                Campo = "Indexador",
                Mensagem = "Não pode ser nulo ou vazio"
            });
        }
    }

    private static void ValidarNomeEmissor(List<ErrosDeValidacaoResposta> erros, string nomeEmissor)
    {
        if (string.IsNullOrEmpty(nomeEmissor))
        {
            erros.Add(new ErrosDeValidacaoResposta()
            {
                Campo = "NomeEmissor",
                Mensagem = "Não pode ser nulo ou vazio"
            });
        }
    }

    private static void ValidarNomeTitulo(List<ErrosDeValidacaoResposta> erros, string nomeTitulo)
    {
        if (string.IsNullOrEmpty(nomeTitulo))
        {
            erros.Add(new ErrosDeValidacaoResposta()
            {
                Campo = "NomeTitulo",
                Mensagem = "Não pode ser nulo ou vazio"
            });
        }
    }

    private static void ValidarRisco(List<ErrosDeValidacaoResposta> erros, string risco)
    {
        if (string.IsNullOrEmpty(risco))
        {
            erros.Add(new ErrosDeValidacaoResposta()
            {
                Campo = "Risco",
                Mensagem = "Não pode ser nulo ou vazio"
            });
        }
        else if (!string.Equals(risco, "MEDIO", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(risco, "BAIXO", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(risco, "ALTO", StringComparison.OrdinalIgnoreCase))
        {
            erros.Add(new ErrosDeValidacaoResposta()
            {
                Campo = "Risco",
                Mensagem = "Deve ser 'MEDIO', 'BAIXO' ou 'ALTO'"
            });
        }
    }

    private static void ValidarDescricao(List<ErrosDeValidacaoResposta> erros, string descricao)
    {
        if (string.IsNullOrEmpty(descricao))
        {
            erros.Add(new ErrosDeValidacaoResposta()
            {
                Campo = "Descricao",
                Mensagem = "Não pode ser nulo ou vazio"
            });
        }
    }

    private static void ValidarHorarioDeNegociacao(List<ErrosDeValidacaoResposta> erros, DateTime horarioFimNegociacao, OfertaDTOPut ofertaDTO)
    {
        if(horarioFimNegociacao <= ofertaDTO.HorarioInicioNegociacao)
        {
            erros.Add(new ErrosDeValidacaoResposta()
            {
                Campo = "HorarioFimNegociacao",
                Mensagem = "Não pode ser menor ou igual a HorarioInicioNegociacao"
            });
        }
    }
    private static void ValidarDataCarencia(List<ErrosDeValidacaoResposta> erros, DateTime dataCarencia, OfertaDTOPut ofertaDTO)
    {
        if(dataCarencia >= ofertaDTO.DataVencimento)
        {
            erros.Add(new ErrosDeValidacaoResposta()
            {
                Campo = "DataVencimento",
                Mensagem = "Não pode ser menor ou igual a DataCarencia"
            });
        }
    }

    private static void ValidarSeEstoqueMaiorQueZero(List<ErrosDeValidacaoResposta> erros, decimal estoque)
    {
        if(ValidarSeMenorQueZero(estoque))
        {
            erros.Add(new ErrosDeValidacaoResposta()
            {
                Campo = "Estoque",
                Mensagem = "Não pode ser menor que zero"
            });
        }
    }
    private static void ValidarSeMaximoResgateMaiorQueZero(List<ErrosDeValidacaoResposta> erros, decimal maximoResgate, OfertaDTOPut ofertaDTO)
    {
        if(ValidarSeMenorQueZero(maximoResgate))
        {
            erros.Add(new ErrosDeValidacaoResposta()
            {
                Campo = "MaximoResgate",
                Mensagem = "Não pode ser menor que zero"
            });
        }
        if(ofertaDTO.MaximoResgate < ofertaDTO.MinimoResgate)
        {
            erros.Add(new ErrosDeValidacaoResposta()
            {
                Campo = "MaximoResgate",
                Mensagem = $"Não pode ser menor que minimo resgate que é {ofertaDTO.MinimoResgate}"
            });
        }
    }

    private static void ValidarSeMinimoResgateMaiorQueZero(List<ErrosDeValidacaoResposta> erros, decimal minimoResgate)
    {
        if(ValidarSeMenorQueZero(minimoResgate))
        {
            erros.Add(new ErrosDeValidacaoResposta()
            {
                Campo = "MinimoResgate",
                Mensagem = "Não pode ser menor que zero"
            });
        }
    }
    private static void ValidarSeMaximoAplicacaoMaiorQueZero(List<ErrosDeValidacaoResposta> erros, decimal maximoAplicacao, OfertaDTOPut ofertaDTO)
    {
        if(ValidarSeMenorQueZero(maximoAplicacao))
        {
            erros.Add(new ErrosDeValidacaoResposta()
            {
                Campo = "MaximoAplicacao",
                Mensagem = "Não pode ser menor que zero"
            });
        }
        if(ofertaDTO.MaximoAplicacao < ofertaDTO.MinimoAplicacao)
        {
            erros.Add(new ErrosDeValidacaoResposta()
            {
                Campo = "MaximoAplicacao",
                Mensagem = $"Não pode ser menor que minimo resgate que é {ofertaDTO.MinimoAplicacao}"
            });
        }
    }

    private static void ValidarSeMinimoAplicacaoMaiorQueZero(List<ErrosDeValidacaoResposta> erros, decimal minimoAplicacao)
    {
        if(ValidarSeMenorQueZero(minimoAplicacao))
        {
            erros.Add(new ErrosDeValidacaoResposta()
            {
                Campo = "MinimoAplicacao",
                Mensagem = "Não pode ser menor que zero"
            });
        }
    }
    
    private static void ValidarSePrecoUnitarioMaiorQueZero(List<ErrosDeValidacaoResposta> erros, decimal precoUnitario)
    {
        if(ValidarSeMenorQueZero(precoUnitario))
        {
            erros.Add(new ErrosDeValidacaoResposta()
            {
                Campo = "PrecoUnitario",
                Mensagem = "Não pode ser menor que zero"
            });
        }
    }
    
    private static void ValidarSeTaxaEmissaoMaiorQueZero(List<ErrosDeValidacaoResposta> erros, decimal taxaEmissao)
    {
        if(ValidarSeMenorQueZero(taxaEmissao))
        {
            erros.Add(new ErrosDeValidacaoResposta()
            {
                Campo = "TaxaEmissao",
                Mensagem = "Não pode ser menor que zero"
            });
        }
    }
    private static void ValidarSeTaxaDistribuicaoMaiorQueZero(List<ErrosDeValidacaoResposta> erros, decimal taxaDistribuicao)
    {
        if(ValidarSeMenorQueZero(taxaDistribuicao))
        {
            erros.Add(new ErrosDeValidacaoResposta()
            {
                Campo = "TaxaDistribuicao",
                Mensagem = "Não pode ser menor que zero"
            });
        }
    }

    private static void ValidarSePorcentagemEmissaoMaiorQueZero(List<ErrosDeValidacaoResposta> erros, decimal porcentagemEmissao)
    {
        if(ValidarSeMenorQueZero(porcentagemEmissao))
        {
            erros.Add(new ErrosDeValidacaoResposta()
            {
                Campo = "PorcentagemEmissao",
                Mensagem = "Não pode ser menor que zero"
            });
        }
    }

    private static void ValidarSePorcentagemDistribuicaoMaiorQueZero(List<ErrosDeValidacaoResposta> erros, decimal porcentagemDistribuicao)
    {
        if(ValidarSeMenorQueZero(porcentagemDistribuicao))
        erros.Add(new ErrosDeValidacaoResposta()
        {
            Campo = "PorcentagemDistribuição",
            Mensagem = "Não pode ser menor que zero"
        });
    }

    private static bool ValidarSeMenorQueZero(decimal valor)
        => valor < 0;
}