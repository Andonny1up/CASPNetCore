using CASPNetCore.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Añadi el servicio de la base da datos
builder.Services.AddDbContext<SchoolContext>(options => options.UseInMemoryDatabase("testDB"));
//Nueva base de datos in azure
//string connString = builder.Configuration.GetConnectionString("DefaultConnectionString");
//builder.Services.AddDbContext<SchoolContext>(options => options.UseSqlServer(connString));

var app = builder.Build();



//Nuevo para asegurarse que la base este creada
using(var scope=app.Services.CreateScope()){
    var serv=scope.ServiceProvider;
    try
    {
        var contex=serv.GetRequiredService<SchoolContext>();
        contex.Database.EnsureCreated();
    }
    catch (System.Exception)
    {
        throw;
    }

}
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
    pattern: "{controller=School}/{action=Index}/{id?}");

app.Run();
