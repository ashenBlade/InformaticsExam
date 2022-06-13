using AspNetCoreSampleApp;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<ITimeService, TimeService>(); // Register as singleton for appropriate use in TimeMiddleware 
builder.Services.AddCors();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseTime(); // Our custom middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.Map("/am-i-gay", b =>
{
    b.UseCors();
    b.Run(async ctx => await ctx.Response.WriteAsync("You are gay"));
});
app.UseAuthorization();
app.MapRazorPages();

app.Run();
