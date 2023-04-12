using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Selfdoctor.Application.Interfaces.Services;
using Selfdoctor.Application.Mappings;
using Selfdoctor.Domain.Interfaces.Repositories;
using Selfdoctor.Domain.Models;
using Selfdoctor.Infrastructure.DbContexts;
using Selfdoctor.Infrastructure.Repositories;
using Selfdoctor.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "AuthCookie";
        options.LoginPath = "/Auth/Register";   
        options.LogoutPath = "/Auth/Logout";
        options.AccessDeniedPath = "/Auth/Register";
        options.ExpireTimeSpan = TimeSpan.FromHours(1);
    });


builder.Services.AddDefaultIdentity<User>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
}).AddRoles<Role>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


builder.Services.AddHttpContextAccessor();


builder.Services.AddAutoMapper(typeof(UserProfile));

builder.Services.AddTransient<IBreastCancerDiagnosisRepository, BreastCancerDiagnosisRepository>();
builder.Services.AddTransient<IBreastCancerDiagnosticRepository, BreastCancerDiagnosticRepository>();
builder.Services.AddTransient<IDiabetesDiagnosticRepository, DiabetesDiagnosticRepository>();
builder.Services.AddTransient<IGenderRepository, GenderRepository>();
builder.Services.AddTransient<IHepatitiscCategoryRepository, HepatitiescCategoryRepository>();
builder.Services.AddTransient<IHepatitiscDiagnosticRepository, HepatitiscDiagnosticRepository>();

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IHepatitisDiagnosticService, HepatitiscDiagnosticSerrvice>();

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
    pattern: "{controller=Auth}/{action=Register}/{id?}");

app.Run();
