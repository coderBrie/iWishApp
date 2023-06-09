﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using iWishApp.Data;
using iWishApp.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = "server=localhost;user=wishapp;password=cashmoney2000;database=user_login";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));
builder.Services.AddDbContext<ApplicationDbContext>(Options => Options.UseMySql(connectionString, serverVersion));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.



builder.Services.AddDefaultIdentity<IdentityUser>
(options =>
{
   options.SignIn.RequireConfirmedAccount = true;
   options.Password.RequireDigit = false;
   options.Password.RequiredLength = 10;
   options.Password.RequireNonAlphanumeric = false;
   options.Password.RequireUppercase = true;
   options.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<ChatbotService>(provider =>
{
    string apiKey = "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";
    return new ChatbotService(apiKey);
});



builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

