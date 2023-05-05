using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace iWishApp.Data;

public class ApplicationDbContext : IdentityDbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
/*    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        *//*modelBuilder.Entity<Event>()
            .HasOne(p => p.Category)
            .WithMany(b => b.events);

        modelBuilder.Entity<Event>()
            .HasMany(p => p.Tags)
            .WithMany(p => p.Events)
            .UsingEntity(j => j.ToTable("EventTags"));*//*
        base.OnModelCreating(modelBuilder);
    }*/


