using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Lab4.Data;
using Lab4.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<UserModel>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();


Seed(builder.Services);

async void Seed(IServiceCollection services)
{
    var bs = services.BuildServiceProvider();
    var roles = bs.GetRequiredService<RoleManager<IdentityRole>>();
    var users = bs.GetRequiredService<UserManager<UserModel>>();
    var db = bs.GetRequiredService<ApplicationDbContext>();

    if (!await roles.RoleExistsAsync("manager"))
        await roles.CreateAsync(new IdentityRole("manager"));
    if (db.Users.OfType<Manager>().FirstOrDefault(i => i.Id == "1") == null)
    {
        var user = new Manager()
        {
            Avatar = @"/wwwroot/avtar.jpg",
            UserName = @"manager@pcz.pl",
            NormalizedUserName = @"manager@pcz.pl",
            Email = @"manager@pcz.pl",
            NormalizedEmail = @"manager@pcz.pl",
            EmailConfirmed = true,
            Id = "1",
            SecurityStamp = string.Empty
        };
        await users.CreateAsync(user, "123##qweQWE");
        await users.AddToRoleAsync(user, "manager");
    }
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
