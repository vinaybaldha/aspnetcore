
using Middleware.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<myCustomMiddleware>();
var app = builder.Build();

app.Use(async(HttpContext context,RequestDelegate next) =>
{
    await context.Response.WriteAsync("middleware 1\n");
    await next(context);
});

app.UseHelloMiddleware();

app.UseWhen(context => context.Request.Query.ContainsKey("firstname"),
        app =>
        {
            app.Use(async(context,next) =>
            {
                await context.Response.WriteAsync("UseWhen\n");
                await next(context);
            });
        }
    );


app.Run(async(HttpContext context) =>
{
    await context.Response.WriteAsync("middleware 3\n");
});

app.Run();
