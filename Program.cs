using Microsoft.EntityFrameworkCore;
using StudentRegestrationSystem.Models;
using Microsoft.AspNetCore.Identity;
using StudentRegestrationSystem.Data;
using StudentRegestrationSystem.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("StudentRegestrationSystemContextConnection") ?? throw new InvalidOperationException("Connection string 'StudentRegestrationSystemContextConnection' not found.");

builder.Services.AddDbContext<StudentRegestrationSystemContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<StudentRegestrationSystemUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<StudentRegestrationSystemContext>();;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Databasecontext>(options => options.UseSqlServer(connectionString));


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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
