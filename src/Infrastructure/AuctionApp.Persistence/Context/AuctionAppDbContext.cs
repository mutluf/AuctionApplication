using AuctionApp.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Persistence.Context;

public class AuctionAppDbContext : IdentityDbContext<AppUser, Role, int>
{
    public AuctionAppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Offer> Offers { get; set; }
    public DbSet<AppUserAuction> AppUserAuctions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AppUserAuction>()
                .HasKey(bc => new { bc.AppUserId, bc.AuctionId });
        modelBuilder.Entity<AppUserAuction>()
            .HasOne(bc => bc.AppUser)
            .WithMany(b => b.AppUserAuctions)
            .HasForeignKey(bc => bc.AppUserId);
        modelBuilder.Entity<AppUserAuction>()
            .HasOne(bc => bc.Auction)
            .WithMany(c => c.AppUserAuctions)
            .HasForeignKey(bc => bc.AuctionId);


    }
}
