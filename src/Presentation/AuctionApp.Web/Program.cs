using AuctionApp.Domain.Entities;
using AuctionApp.Infrastructure.Hubs;
using AuctionApp.Infrastructure.SqlTableDependency;
using AuctionApp.Persistence;
using AuctionApp.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AuctionApp.Infrastructure.SqlTableDependency;
using AuctionApp.Infrastructure.SqlTableDependency.Middleware;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var assembly = AppDomain.CurrentDomain.GetAssemblies();

builder.Services.AddSingleton<DatabaseSubscription<Offer>>();
builder.Services.AddDbContext<AuctionAppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AuctionAppDbContext>();

var config = builder.Configuration;

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;

});

builder.Services.AddPersistenceService();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddAuthentication()
   .AddGoogle(options =>
   {
       options.ClientId = builder.Configuration["ClientId"];
       options.ClientSecret = builder.Configuration["ClientSecret"];
   });
builder.Services.AddSignalR(e => {
    e.MaximumReceiveMessageSize = 102400000;
    e.EnableDetailedErrors = true;
});//Buradan core olmayanýný çaðýracaðýz.

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
app.UseHangfireDashboard();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseDatabaseSubscription<DatabaseSubscription<Offer>>("Offers");
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{

    endpoints.MapHub<OfferHub>("/offershub");
});

app.MapControllerRoute(
  name: "admin",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();