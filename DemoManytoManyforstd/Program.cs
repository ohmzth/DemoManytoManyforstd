using DemoManytoManyforstd.Data;
using DemoManytoManyforstd.Helpers;
using DemoManytoManyforstd.Interfaces;
using DemoManytoManyforstd.Repositories;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ManytoManyContext>(options =>
{
    options.UseSqlServer(

         builder.Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.AddTransient<IUnitOfWork, UnitOfWorkRepo>();

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new Helper());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddControllersWithViews();
    
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
    pattern: "{controller=posts}/{action=Index}/{id?}");

app.Run();
