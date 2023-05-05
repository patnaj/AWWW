using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Lab4Test.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();


// 
seed(builder.Services);

async void seed(IServiceCollection services)
{
    var b = services.BuildServiceProvider();
    var roles  = b.GetRequiredService<RoleManager<IdentityRole>>();
    if(! await roles.RoleExistsAsync("manager")){
        await roles.CreateAsync(new IdentityRole("manager"));
    }
    var users  = b.GetRequiredService<UserManager<IdentityUser>>();
    if((await users.FindByIdAsync("2")) == null){
    
        var user = new IdentityUser(){
            Id="2",
            Email="test2@pcz.pl",
            NormalizedEmail="test2@pcz.pl",
            NormalizedUserName = "test2@pcz.pl",
            UserName="test2@pcz.pl",
            EmailConfirmed=true,
            SecurityStamp=String.Empty
        };
        
        await users.CreateAsync(user, "qwe#123QWE");
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
