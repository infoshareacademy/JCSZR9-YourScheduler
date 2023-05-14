using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YourScheduler.BusinessLogic.Initialization;
using YourScheduler.BusinessLogic.Models;
using YourScheduler.Infrastructure;
using YourScheduler.Infrastructure.Initialization;
using YourScheduler.Infrastructure.Entities;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("YourSchedulerDbContextConnection") ?? throw new InvalidOperationException("Connection string 'YourSchedulerDbContextConnection' not found.");

builder.Services.AddDbContext<YourSchedulerDbContext>(options =>
 options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
 .AddEntityFrameworkStores<YourSchedulerDbContext>();
//var connectionString = builder.Configuration.GetConnectionString("YourSchedulerDbContextConnection") ?? throw new InvalidOperationException("Connection string 'YourSchedulerDbContextConnection' not found.");

//builder.Services.AddDbContext<YourSchedulerDbContext>(options =>
//options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
// .AddEntityFrameworkStores<YourSchedulerDbContext>();
//var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");





builder.Services.AddInfrastructureDependencies(builder.Configuration);
//builder.Services.AddDbContext<YourSchedulerDbContext>(options =>
//options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
  //  .AddEntityFrameworkStores<YourSchedulerDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization();

builder.Services.AddBusinessLogicDependencies();


//builder.Services.AddDefaultIdentity<UserDto>(options => options.SignIn.RequireConfirmedAccount = false);//PAMI�TA� O TEJ ZMIANIE (NIE TRZEBA POTWIERDZA� MAILA TERAZ)
//.AddEntityFrameworkStores<YourSchedulerDbContext>();

// Add services to the container.


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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Privacy}/{id?}");

app.MapRazorPages();
app.Run();

