﻿using CommonTypesLayer.Utilities;
using ETS.Business.CustomExceptions;
using ETS.Model.Entities;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace ETS.WebApi.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = StatusCodes.Status500InternalServerError;

                    switch (exceptionFeature.Error)
                    {
                        case BadRequestException:
                            statusCode = StatusCodes.Status400BadRequest;
                            break;
                        case NoContentException:
                            statusCode = StatusCodes.Status204NoContent;
                            break;
                        case NotFoundException:
                            statusCode = StatusCodes.Status404NotFound;
                            break;
                    }
                    context.Response.StatusCode = statusCode;
                    var response = ApiResponse<Structure>.Fail(statusCode, exceptionFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
