using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Business.Exceptions
{
    public class WeatherServiceException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public WeatherServiceException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
