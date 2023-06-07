using Microsoft.AspNetCore.Identity;

namespace AuctionApp.Domain.Entities;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser<int>
{
    public AppUser()
    {
        AppUserAuctions = new HashSet<AppUserAuction>();
    }
    public string? Surname { get; set; }
    public string? Name { get; set; }
    public ICollection<AppUserAuction> AppUserAuctions { get; set; }

    public ICollection<Product> Products { get; set; }
}

