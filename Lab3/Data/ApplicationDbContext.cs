using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Lab3.Models;

namespace Lab3.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<ProductModel> Products { get; set; } 
    public DbSet<CatalogModel> Catalogs { get; set; }
    public DbSet<TagModel> Tags { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

}
