using Lab2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Data;

#pragma warning disable CS8618
public class ApplicationDbContext : IdentityDbContext
{
    //tabele sql
    public DbSet<ProductModel> Products { get; set; } 
    public DbSet<CatalogModel> Catalogs { get; set; }
    public DbSet<TagModel> Tags { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<TagModel>().HasData(
            new TagModel(){Id=1, Title="Nowość"},
            new TagModel(){Id=2, Title="Przecena"}
        );
    }
}
