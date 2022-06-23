using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

public class ExceptionFilter : IAsyncExceptionFilter
{
    public async Task OnExceptionAsync(ExceptionContext context)
    {
        HttpResponse response = context.HttpContext.Response;
        response.StatusCode = (int)HttpStatusCode.InternalServerError;
        response.ContentType = "application/json";
        await response.WriteAsync($"Aconteceu um erro inesperado, por favor contate o suporte");
    }
}