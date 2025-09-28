using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using NTA.Core.DTOs;
using NTA.Service.Exceptions;

namespace NTA.Middlewares;

public static class UseCustomExceptionHandler
{
    public static void UseCustomException(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(config =>
        {
            config.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                    var exceptionFeature=context.Features.Get<IExceptionHandlerPathFeature>();
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 404, 
                        _=> 500
                    };
                    context.Response.StatusCode=statusCode;
                    var response =CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            });
        });
    }
}