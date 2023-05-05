using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Lab4.Models;
using Microsoft.AspNetCore.Identity;

namespace Lab4.Data;

public class ApplicationDbContext : IdentityDbContext<UserModel, IdentityRole, string>
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<UserModel>()
        .HasDiscriminator<string>("UType")
        .HasValue<UserModel>("user")
        .HasValue<Manager>("manager");        
    }
}
