using Microsoft.Extensions.FileProviders;
using RoutingExample.CustomRoutingConstrains;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath="myroot"
});
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("months",typeof(MyContrain));
});
var app = builder.Build();

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine( builder.Environment.ContentRootPath,"mywebroot")
        )
   
});

app.UseRouting();


/*
app.Use(async(context, next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
    if (endPoint != null)
    {
        await context.Response.WriteAsync($"endPoint: {endPoint.DisplayName}\n");
    }
   await next();
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("map1", async(context) =>
    {
        await context.Response.WriteAsync("map1 used!");
    });

    endpoints.MapPost("map2", async (context) =>
    {
        await context.Response.WriteAsync("map2 used!");
    });
});
*/

app.UseEndpoints(endpoints =>
{
    endpoints.Map("files/{filename}.{extention}",async (context) =>
    {
        string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extention = Convert.ToString(context.Request.RouteValues["extention"]);

       await context.Response.WriteAsync($"file : {filename} - {extention}");
    });

    endpoints.Map("profile/{EmployeeName}",async (context) =>
    {
        string? employeeName=Convert.ToString( context.Request.RouteValues["employeeName"]);

        await context.Response.WriteAsync($"Name: {employeeName}");
    });

    //employee/1

    endpoints.Map("profile/employee/{id?}", async (context) =>
    {
        if (context.Request.RouteValues.ContainsKey("id"))
        {
            int? id = Convert.ToInt32(context.Request.RouteValues["id"]);

            await context.Response.WriteAsync($"id: {id}");
        }
        else
        {
            await context.Response.WriteAsync("id: id not supplied");
        }
        
    });

    // daily-report/{reportDate}
    endpoints.Map("daily-report/{date:datetime}", async context =>
    {
        DateTime date= Convert.ToDateTime(context.Request.RouteValues["date"]);
        await context.Response.WriteAsync($"date: {date}");
    });

    //cites/{cityid:guid}
    endpoints.Map("cites/{cityid:guid}",async context =>
    {
      Guid cityid= Guid.Parse(Convert.ToString( context.Request.RouteValues["cityid"])!);

        await context.Response.WriteAsync($"cityid: {cityid}");
    });

    //year/month
    endpoints.Map("{year:int:min(1900)}/{month:months}",async context =>
    {
        int year=Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);

        await context.Response.WriteAsync($"year: {year}, month: {month}");

    });

    //2024/may
    endpoints.Map("2024/may",async context =>
    {
        await context.Response.WriteAsync("May 2024 report generated...");
    });
});

app.Run(async(context) =>
{
    await context.Response.WriteAsync($"path: {context.Request.Path}");
});
app.Run();
