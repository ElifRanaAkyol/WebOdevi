using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebOdevi.Data;
using WebOdevi.Models;

var builder = WebApplication.CreateBuilder(args);

// DB Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// seed
await SeedRolesAndAdminAsync(app);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

app.Run();


// Seed method
async Task SeedRolesAndAdminAsync(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<User>>();

    // roles
    string[] roles = new[] { "Admin", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }

    // admin
    var adminEmail = "b231210092@sakarya.edu.tr";
    var admin = await userManager.FindByEmailAsync(adminEmail);

    if (admin == null)
    {
        admin = new User
        {
            Email = adminEmail,
            UserName = adminEmail,
            FullName = "Admin",
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(admin, "sau123");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }

    // database seed
    AppDbInitializer.Seed(app);
}
