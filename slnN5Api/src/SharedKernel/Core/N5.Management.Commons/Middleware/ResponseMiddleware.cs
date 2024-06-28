using N5.Management.Commons.Dto;
using Newtonsoft.Json.Serialization;

namespace N5.Management.Commons.Middleware
{
    public class ResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalResponse = context.Response.Body;
            
            try
            {
                using (var responseBody = new MemoryStream())
                {
                    context.Response.Body = responseBody;

                    await _next(context);

                    context.Response.Body = originalResponse;
                    responseBody.Seek(0, SeekOrigin.Begin);
                    var responseContent = await new StreamReader(responseBody).ReadToEndAsync();

                    var responseDto = new ResponseDTO
                    {
                        TransactionId = DateTime.Now.ToString(Constants.Core.DateTimeFormats.DD_MM_YYYY_HH_MM_SS_FFF),
                        Status = context.Response.StatusCode,
                        Success = context.Response.StatusCode >= 200 && context.Response.StatusCode < 300,
                        Data = JsonConvert.DeserializeObject<dynamic>(responseContent)
                    };

                    responseBody.Seek(0, SeekOrigin.Begin);
                    context.Response.Body = originalResponse;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(responseDto));
                    Log.Information("SUCCESS: {@Data}", JsonConvert.SerializeObject(responseDto.Data));
                }
            }
            catch (Exception ex)
            {
                context.Response.Body = originalResponse;
                await HandleExceptionAsync(context, ex);
            }
            finally
            {
                context.Response.Body = originalResponse;
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            string message = string.Empty;

            switch (ex)
            {
                case FunctionalException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    message = ex.Message;
                    Log.Error("FunctionalException: {@ex}", JsonConvert.SerializeObject(ex));
                    break;

                case TechnicalException:
                    httpStatusCode = HttpStatusCode.InternalServerError;
                    message = "Se ha producido un error tecnico.";
                    Log.Error("TechnicalException: {@ex}", JsonConvert.SerializeObject(ex));
                    break;

                default:
                    httpStatusCode = HttpStatusCode.InternalServerError;
                    message = $"Se ha producido un error al procesar solicitud: {ex.Message}";
                    Log.Error("Exception: {@ex}", JsonConvert.SerializeObject(ex));
                    break;
            }

            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)httpStatusCode;

                context.Response.Body = context.Response.Body;
                var errorResult = new N5Exception((int)httpStatusCode, message);
                await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResult));
            }
        }

   }
}
