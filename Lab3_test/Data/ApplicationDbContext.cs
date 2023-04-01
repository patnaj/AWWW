using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Lab3_test.Models;

namespace Lab3_test.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<PersonModel> Persons { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
