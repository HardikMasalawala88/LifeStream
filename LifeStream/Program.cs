using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LifeStream.Data;
using LifeStream.Areas.Identity.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("LifeStreamdDBContextConnection")
    ?? throw new InvalidOperationException("Connection string 'LifeStreamdDBContextConnection' not found.");

builder.Services.AddDbContext<LifeStreamdDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<LifeStreamUser>(options =>
    options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LifeStreamdDBContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

#region Swagger
// Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mobile API",
        Version = "v1"
    });

    // Show only MobileAPIController
    c.DocInclusionPredicate((docName, apiDesc) =>
    {
        var actionDescriptor = apiDesc.ActionDescriptor;
        if (actionDescriptor is Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor controllerActionDescriptor)
        {
            return controllerActionDescriptor.ControllerTypeInfo.Name == "MobileAPIController";
        }
        return false;
    });
});
#endregion
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<LifeStreamUser>>();

    string[] roleNames = { "Admin", "Doctor", "Patient", "Receptionist" };

    foreach (var roleName in roleNames)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    var adminEmail = "admin@lifestream.com";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);

    if (adminUser == null)
    {
        adminUser = new LifeStreamUser
        {
            UserName = adminEmail,
            Email ="admin@lifestream.com",
            EmailConfirmed = true,
            FirstName = "LifeStream",
            LastName = "Admin"
        };

        var result = await userManager.CreateAsync(adminUser, "Admin@123");

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}

if (!app.Environment.IsDevelopment())
{   
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();    
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();