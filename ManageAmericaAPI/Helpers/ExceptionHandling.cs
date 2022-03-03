using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace ManageAmericaAPI.Helpers
{
    public class ExceptionHandling
    {
        public RequestDelegate requestDelegate;
       
        public ExceptionHandling(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context, ILogger<ExceptionHandling> logger)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex,logger);
            }
        }
        private static Task HandleException(HttpContext context, Exception ex, ILogger<ExceptionHandling> logger)
        {
            logger.LogError(ex.ToString());
            var errorMessageObject = new Error { Message = ex.Message, Code = "GE" };
            var statusCode = (int)HttpStatusCode.InternalServerError;
            switch(ex)
            {
                case InvalidException:
                    errorMessageObject.Code = "M001";
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case HttpResponseException:
                    errorMessageObject.Code = "404";
                    statusCode = (int)HttpStatusCode.NotFound;
                    break;

                case UnSucessFullException:
                    errorMessageObject.Code = "400";
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case ConflictException:
                    errorMessageObject.Code = "409";
                    statusCode = (int)HttpStatusCode.Conflict;
                    break;

            }
            var errorMessage = JsonConvert.SerializeObject(errorMessageObject);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(errorMessage);
        }
    }
}
