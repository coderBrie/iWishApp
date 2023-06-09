using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using iWishApp.Models;

namespace iWishApp.Data;



public class ApplicationDbContext : IdentityDbContext
{

    public DbSet<Affirmations>? Affirmations { get; set; }
    public DbSet<Journals>? Journals { get; set; }



    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Affirmations>().ToTable("Wishlist");
        modelBuilder.Entity<Journals>().ToTable("Journals");
        base.OnModelCreating(modelBuilder);
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


