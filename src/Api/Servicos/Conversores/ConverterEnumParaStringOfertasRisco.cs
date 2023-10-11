using CrudOfertas.Api.Repositorios.Enuns;

namespace CrudOfertas.Api.Servicos.Conversores;
public class ConverterEnumParaStringOfertasRisco
{
    public static string ConverterEnumParaString(RiscoOferta risco)
    {
        return risco.ToString();
    }
}