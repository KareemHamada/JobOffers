using Bl;
using Domains;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<JobOfferContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddIdentityCore<ApplicationUser>().AddEntityFrameworkStores<JobOfferContext>();
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//        .AddEntityFrameworkStores<JobOfferContext>()
//        .AddDefaultTokenProviders();



builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<JobOfferContext>();

builder.Services.AddScoped<ICategories, clsCategories>();
builder.Services.AddScoped<IJobDetails, clsJobDetails>();
builder.Services.AddScoped<IJobLocations, clsJobLocation>();
builder.Services.AddScoped<IJobTypes, clsJobType>();
builder.Services.AddScoped<IApplyForJob, ClsApplyForJob>();

//builder.Services.AddDefaultIdentity<ApplicationUser>().AddEntityFrameworkStores<JobOfferContext>();



// for login
builder.Services.ConfigureApplicationCookie(Options =>
{
    Options.AccessDeniedPath = "/User/AccessDenied";
    Options.Cookie.Name = "Cookie";
    Options.Cookie.HttpOnly = true;
    Options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
    Options.LoginPath = "/User/Login";
    Options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    Options.SlidingExpiration = true;
});

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


app.UseStatusCodePagesWithReExecute("/Error{0}");


app.UseEndpoints(endpoints =>
{

    endpoints.MapAreaControllerRoute(
        name: "admin",
        areaName: "admin",
        pattern: "admin/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
    name: "error",
    pattern: "/Error{statusCode}",
    defaults: new { controller = "Error", action = "Handle" });


    endpoints.MapControllerRoute(
       name: "Default",
       pattern: "{controller=Home}/{action=Index}/{id?}"
       );

    //endpoints.MapControllerRoute(
    //name: "admin",
    //pattern: "{area=exists}/{controller=Home}/{action=Index}"
    //);

});

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
