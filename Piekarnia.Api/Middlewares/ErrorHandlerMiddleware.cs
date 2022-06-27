using System;
using System.Threading.Tasks;
using Piekarnia.Domain.DomainExceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Piekarnia.Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                /*                var exp = e.GetBaseException();
                                exp.GetType();*/
                await HandleErrorAsync(context, e);
            }
        }

        private Task HandleErrorAsync(HttpContext context, Exception e)
        {
            var exceptionResult = GetException(e);
            var response = new { message = exceptionResult.Item1 };
            var payload = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exceptionResult.Item2;
            return context.Response.WriteAsync(payload);
        }

        private (string, int) GetException(Exception e)
        {
            Console.WriteLine(e);
            var key = _exceptionDictionary.Keys.FirstOrDefault(x => x(e));
            if (key == null)
            {
                return ("Internal Server Error "+e.ToString(), 500);
            }
            return _exceptionDictionary[key](e);
        }

        private Dictionary<Func<Exception, bool>, Func<Exception, (string, int)>> _exceptionDictionary =
            new Dictionary<Func<Exception, bool>, Func<Exception, (string, int)>>
            {
                [e => e.GetBaseException() is InvalidNameSurnameException]
                    = e => (e.GetBaseException().Message, 400)
            };
    }
}