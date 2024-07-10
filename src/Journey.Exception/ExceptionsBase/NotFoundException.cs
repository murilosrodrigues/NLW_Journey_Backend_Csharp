using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Journey.Exception.ExceptionsBase;
public class NotFoundException : JourneyException
{
    public NotFoundException(string message) : base(message) 
    {
        
    }

    public override HttpStatusCode GetStatusCode()
    {
        return  HttpStatusCode.BadRequest;
    }

    public override IList<string> GetErrorMessages()
    {
        return new List<string>()
        {
            Message
        };
    }
}
