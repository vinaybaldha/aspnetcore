using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context ) =>
{

    /*if (1 == 1)
    {
        context.Response.StatusCode = 200;
    }
    else
    {
        context.Response.StatusCode = 400;
    }
    string path = context.Request.Path;
    string method = context.Request.Method;
   // context.Response.Headers["MyKey"] = "my value";
   // context.Response.Headers["Server"] = "My Server";
    context.Response.Headers["Content-Type"] = "text/html";
    
        if (context.Request.Headers.ContainsKey("Authorization-Key"))
        {
            string auth = context.Request.Headers["Authorization-Key"];
            await context.Response.WriteAsync($"<h1>{auth}</h1>");
        }
    
    
   
  // await context.Response.WriteAsync($"<h2>{method}</h2>");*/

    StreamReader reader = new StreamReader(context.Request.Body);
    string body = await reader.ReadToEndAsync();
    Dictionary<string, StringValues> queryDisc = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

    if (queryDisc.ContainsKey("FirstName")){
        string firstName = queryDisc["FirstName"][0];
        await context.Response.WriteAsync(firstName);
    }

});

app.Run();
