using AuctionApp.Domain.Entities;
using AuctionApp.Persistence;
using AuctionApp.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var assembly = AppDomain.CurrentDomain.GetAssemblies();


builder.Services.AddDbContext<AuctionAppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AuctionAppDbContext>();

var config = builder.Configuration;



builder.Services.AddPersistenceService();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddAuthentication()
   .AddGoogle(options =>
   {
       options.ClientId = builder.Configuration["ClientId"];
       options.ClientSecret = builder.Configuration["ClientSecret"];
   });

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
//app.MapDefaultControllerRoute();


//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapAreaControllerRoute(
//        name: "Admin",
//        areaName: "Admin",
//        pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
//        );

//	endpoints.MapDefaultControllerRoute();

//});

app.MapControllerRoute(
  name: "admin",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();