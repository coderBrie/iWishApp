using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using iWishApp.Models;

namespace iWishApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Users>? UserLogin { get; set; }  
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}

