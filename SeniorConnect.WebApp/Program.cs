using Microsoft.AspNetCore.Authentication.Cookies;
using SeniorConnect.DataAccessLibrary;
using SeniorConnect.Application.Services;
using SeniorConnect.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddInfrastructure(); 
builder.Services.AddScoped<IdentityService>();


//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options => {
//        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
//        options.LoginPath = new PathString("/Pages/IdentityAccessManagement/Login");
//        options.AccessDeniedPath = new PathString("/Pages/Forbidden");
//}
//);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

