using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Mime;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages(); 
builder.Services.AddControllers(); 
builder.Services.AddProblemDetails(); 

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); 
}
else
{
    app.UseExceptionHandler("/Error"); 
    app.UseHsts(); 
}

app.UseHttpsRedirection(); 
app.UseStaticFiles(); 
app.UseRouting(); 

app.UseAuthorization(); 

app.MapControllers(); 
app.MapRazorPages(); 


app.UseStatusCodePages(async context =>
{
    context.HttpContext.Response.ContentType = Text.Plain;
    var statusCode = context.HttpContext.Response.StatusCode;

    if (statusCode == StatusCodes.Status404NotFound)
    {
        await context.HttpContext.Response.WriteAsync("Página não encontrada.");
    }
});

app.Run();