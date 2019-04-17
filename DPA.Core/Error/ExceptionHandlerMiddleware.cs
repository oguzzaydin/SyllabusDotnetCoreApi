using System;
using System.Text;
using System.Threading.Tasks;
using DPA.Core.Error.Result;
using DPA.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DPA.Core.Error
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task<IServiceResult> HandleExceptionAsync(HttpContext context, Exception exception)
        {
            IServiceResult result;
            if (exception is DpaException || exception is JsonSerializationException && exception.InnerException?.InnerException is DpaException)
            {
                var dpaException = (exception is DpaException ? exception : exception.InnerException.InnerException) as DpaException;
                result = dpaException.ToServiceResult();
            }
            else
                result = new ServiceResult(new ServiceError("500", exception.GetType().Name, exception), 500);
            context.Response.StatusCode = result.Code;
            context.Response.ContentType = "application/json; charset=utf-8";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
            return result;
        }
    }
}
