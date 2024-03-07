
namespace Middleware.CustomMiddleware
{
    public class myCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("customMiddleware start\n");
            await next(context);
            await context.Response.WriteAsync("customMiddleware end\n");
        }
    }

    public static class MyMiddlewareExtention
    {
        public static IApplicationBuilder UseMyMiddleware (this IApplicationBuilder app)
        {
           return app.UseMiddleware<myCustomMiddleware>();
        }
    }
}
