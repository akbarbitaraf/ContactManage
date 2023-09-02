

using ContactManageTools;
using ContactManageEntities.DTO;
using System.Text;

namespace ContactManage.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;

        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
          
            string stringBody = string.Empty;
            try
            {
                httpContext.Request.EnableBuffering();
                stringBody = await (new StreamReader(httpContext.Request.Body).ReadToEndAsync());
                httpContext.Request.Body.Position = 0;
                await _next(httpContext);
            }
            catch (GeneralException ex)
            {
                await HandleExceptionAsync(httpContext, ex, stringBody);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, GeneralException exception, string requestBody)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)exception.status;
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.message
            }.ToString());

            try
            {
                var str = new StringBuilder();
                str.AppendLine("🍆 StatusCode: " + context.Response.StatusCode);
                str.AppendLine("🗣 Request: " + context.Request.Path + ". QueryString: " + context.Request.QueryString.ToString() + ". Body: " + requestBody);
                str.AppendLine("✍️ Exception Message: " + exception.Message);
                str.AppendLine("💩 Full Exception: " + exception.ToString());

            }
            catch { }
        }
    }
}
