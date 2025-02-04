using Microsoft.AspNetCore.Identity;
using Tamirci.Entities.Bases;

namespace Tamirci.Entities;
public class AppUser : IdentityUser, IHasCreateDate, IHasUpdateDate
{
    public DateTime UpdateDate { get; set; }
    public DateTime CreateDate { get; set; }
    public virtual RefreshToken RefreshToken { get; set; } = null!;
}
