using System.Configuration;
using FuncionarioMVC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ));


var app = builder.Build();

GeradorDeServicos.ServiceProvider = builder.Services.BuildServiceProvider();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();