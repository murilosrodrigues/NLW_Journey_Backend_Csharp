namespace Journey.Communication.Responses;

public class ResponseErrorsJson
{
    public IList<string> Erros { get; set; } = [];

    public ResponseErrorsJson(IList<string> errors)
    {
        Erros = errors;
    }
}
