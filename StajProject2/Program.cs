using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>();

// Register application services
builder.Services.AddScoped<IAppUserService, AppUserManager>();
builder.Services.AddScoped<IAppUserDal, EFAppUserDal>();

//builder.Services.AddSingleton<IAppUserDal, EFAppUserDal>();
//builder.Services.AddTransient<IAppUserDal, EFAppUserDal>();

builder.Services.AddScoped<IPoliceService, PoliceManager>();
builder.Services.AddScoped<IPoliceDal, EFPoliceDal>();

builder.Services.AddScoped<IPaymentService, PaymentManager>();
builder.Services.AddScoped<IPaymentDal, EFPaymentDal>();

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
