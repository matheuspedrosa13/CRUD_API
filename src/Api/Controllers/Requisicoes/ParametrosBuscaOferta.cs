namespace CrudOfertas.Api.Controllers.Requisicoes;

public class ParametrosBuscaOferta
{
    public string Nome { get; set; } = String.Empty;
    public bool? Liquidez {get;set;}
    public bool Aprovada {get;set;}
}
