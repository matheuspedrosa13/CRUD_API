using CrudOfertas.Api.Repositorios.Enuns;

namespace CrudOfertas.Api.Servicos;
public class ConverterStringParaEnumOfertasRisco
{
    public static RiscoOferta ConverterStringParaEnum(string risco)
    {
        risco = risco.ToUpper();
        if (Enum.TryParse(risco, out RiscoOferta valorDoEnum))
        {
            return valorDoEnum;
        }
        else
        {
            throw new ArgumentException("Valor de risco inválido: " + risco);
        }
    }
}