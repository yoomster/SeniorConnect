using Microsoft.AspNetCore.Authentication.Cookies;
using SeniorConnect.DataAccessLibrary;
using SeniorConnect.Application.Services;
using SeniorConnect.Application.Interfaces;
using SeniorConnect.Domain;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddInfrastructure(); 
builder.Services.AddScoped<IdentityService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IValidator, UserValidator>();
//builder.Services.AddScoped<ProfileService>();
builder.Services.AddScoped<ActivityService>();
builder.Services.AddHttpContextAccessor();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.LoginPath = new PathString("/IdentityAccessManagement/Login");
        options.AccessDeniedPath = new PathString("/Forbidden");

    }
);
builder.Services.AddDistributedMemoryCache();

//short timeout to simplify testing
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


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

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.UseDeveloperExceptionPage();
app.Run();

