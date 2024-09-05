using JetBrains.Annotations;
using Microsoft.AspNetCore.Connections;
using System.Net.Mime;
using System.Net;

using Shared.Exceptions;
using System.Text.Json;

namespace HospitalApi.Middlewares;

[UsedImplicitly(ImplicitUseTargetFlags.Members)]
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BadHttpRequestException ex) when (ex.Message is "Unexpected end of request content.")
        {
            // Do nothing
        }
        catch (IOException ex) when (ex.Message is "The client reset the request stream."
                                         or "The request stream was aborted.")
        {
            // Do nothing
        }
        catch (ConnectionResetException)
        {
            // Do nothing
        }
        catch (ArgumentException ex)
        {
            await WriteGenericErrorAsync(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (HospitalNotFoundException ex)
        {
            await WriteGenericErrorAsync(context, HttpStatusCode.NotFound, ex.Message);
        }
        catch (FormatException ex)
        {
            await WriteGenericErrorAsync(context, HttpStatusCode.BadRequest, ex.Message);
        }

        catch (HospitalDuplicateException ex)
        {
            await WriteGenericErrorAsync(context, HttpStatusCode.UnprocessableEntity, ex.Message);
        }
        catch (Exception e)
        {
            await WriteGenericErrorAsync(context, HttpStatusCode.InternalServerError, e.Message);
        }
    }

    private Task WriteGenericErrorAsync(HttpContext context, HttpStatusCode statusCode, string errorMessage)
    {
        context.Response.ContentType = MediaTypeNames.Application.Json;

        context.Response.StatusCode = (int)statusCode;

        var message = JsonSerializer.Serialize(errorMessage, new JsonSerializerOptions(new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        }));

        return context.Response.WriteAsync(message);
    }
}
