using Microsoft.EntityFrameworkCore;
using WebCRUDmvcSQL.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Normalmente se coloca aqui a string de conexão
builder.Services.AddDbContext<Contexto>
    (options => options.UseSqlServer
    (@"Data Source=localhost; initial Catalog=CRUDmvc_YT; User ID=usuario;password=senha;language=Portuguese;Trusted_Connection=True"));


var app = builder.Build();

// Configure the HTTP request pipeline.
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
