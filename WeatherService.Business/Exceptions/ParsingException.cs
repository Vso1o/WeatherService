using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Business.Exceptions.Abstractions;

namespace WeatherService.Business.Exceptions
{
    public class ParsingException : ApiException
    {
        public ParsingException(string message, string? paramName) : base(HttpStatusCode.InternalServerError, message)
        {
            paramName = paramName ?? string.Empty;
        }

        public ParsingException(string message, string? paramName, Exception ex) : base(HttpStatusCode.InternalServerError, message, ex)
        {
            paramName = paramName ?? string.Empty;
        }
    }
}
