using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<CatalogModel> Catalogs { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
