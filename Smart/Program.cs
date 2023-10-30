using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using Smart.Data;
using Smart.Services;
using Smart.Services.Interface;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEntityFrameworkMySQL()
    .AddDbContext<SmartContext>(options =>
    {
        options.UseMySQL(builder.Configuration.GetConnectionString("SmartOptions"));
    });
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IClienteService, ClienteService>();
var app = builder.Build();
//

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedingService.Initialize(services);
}
//
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
