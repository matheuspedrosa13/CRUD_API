using CrudOfertas.Api.Repositorios.DAOs;

namespace CrudOfertas.Api.Servicos;
public class ValidarAtualizarOferta
{
    public static void ValidarOferta(OfertaDAO ofertaExistente, Dictionary<string, object> colunasAtualizadas)
    {
        if (ofertaExistente != null)
        {
            ofertaExistente.DataAtualizacao = DateTime.Now;

            foreach (var colunaAtualizada in colunasAtualizadas)
            {

                switch (colunaAtualizada.Key)
                {
                    case "porcentagemEmissao":
                        Console.WriteLine("asa");
                        Console.WriteLine(ofertaExistente.Id);

                        if (colunaAtualizada.Value is decimal porcentagemEmissao)
                        
                        {
                            Console.WriteLine("asa");

                            ofertaExistente.PorcentagemEmissao = porcentagemEmissao;
                        }
                        break;
                    case "porcentagemDistribuicao":
                        if (colunaAtualizada.Value is decimal porcentagemDistribuicao)
                        {
                            ofertaExistente.PorcentagemDistribuicao = porcentagemDistribuicao;
                        }
                        break;
                    case "dataCarencia":
                        if (colunaAtualizada.Value is DateTime dataCarencia)
                        {
                            if (dataCarencia < ofertaExistente.DataVencimento)
                            {
                                ofertaExistente.DataCarencia = dataCarencia;
                            }
                            else
                            {
                                Console.WriteLine("A data de carência deve ser anterior à data de vencimento.");
                            }
                        }
                        break;
                    case "horarioInicioNegociacao":
                        if (colunaAtualizada.Value is DateTime horarioInicioNegociacao)
                        {
                            if (horarioInicioNegociacao < ofertaExistente.HorarioFimNegociacao)
                            {
                                ofertaExistente.HorarioInicioNegociacao = horarioInicioNegociacao;
                            }
                            else
                            {
                                Console.WriteLine("O horário de início de negociação deve ser anterior ao horário de fim.");
                            }
                        }
                        break;
                    case "horarioFimNegociacao":
                        if (colunaAtualizada.Value is DateTime horarioFimNegociacao)
                        {
                            if (ofertaExistente.HorarioInicioNegociacao < horarioFimNegociacao)
                            {
                                ofertaExistente.HorarioFimNegociacao = horarioFimNegociacao;
                            }
                            else
                            {
                                Console.WriteLine("O horário de fim de negociação deve ser posterior ao horário de início.");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}