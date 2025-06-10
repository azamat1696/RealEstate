using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RealEstateUI.Services;

var builder = WebApplication.CreateBuilder(args);

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub"); // Remove the default "sub" claim mapping

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.LoginPath = "/Login/Index";
    options.LogoutPath = "/Login/Logout";
    options.AccessDeniedPath = "/Login/AccessDenied";
    options.Cookie.HttpOnly = true;
    options.Cookie.SameSite = SameSiteMode.Strict;
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Use Always for production
    options.Cookie.Name = "RealEstateAuthCookie";
});


builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ILoginService, LoginService>();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "EstateAgent",
            pattern: "{area:exists}/{controller=MyAdverts}/{action=Index}/{id?}"
        );
    });

app.Run();