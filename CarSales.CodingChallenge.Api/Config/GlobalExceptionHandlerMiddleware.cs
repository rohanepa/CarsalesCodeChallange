﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;


namespace CarSales.CodingChallenge.Api.Config
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            Log.Error(exception, "An unexpected error occured while processing the request");

            var response = context.Response;
            response.ContentType = "application/json";

            await HandlerUnexpectedException(exception, response);
        }

        private async Task HandlerUnexpectedException(Exception exception, HttpResponse response)
        {
            response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorResponse = new UnexpectedErrorResponse
            {
                Message = "Oops.. this is embarrassing. An unexpected error occured"
            };

            var currentException = exception;
            while (true)
            {
                errorResponse.Errors.Add(new UnexpectedError
                {
                    Message = currentException.Message,
                    StackTrace = currentException.StackTrace
                });

                if (currentException.InnerException == null)
                    break;

                currentException = currentException.InnerException;
            }

            await SetReturnResponseInHttpResponse(errorResponse, response);

        }

        private async Task SetReturnResponseInHttpResponse<T>(T errorResponse, HttpResponse response) where T : class
        {
            await response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
        }

        public class UnexpectedErrorResponse
        {
            public string Message { get; set; }

            public List<UnexpectedError> Errors { get; } = new List<UnexpectedError>();

        }

        public class UnexpectedError
        {
            public string Message { get; set; }
            public string StackTrace { get; set; }
        }
    }
}
