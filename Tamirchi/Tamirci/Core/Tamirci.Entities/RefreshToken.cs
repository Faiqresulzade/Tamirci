using Tamirci.Entities.Bases;

namespace Tamirci.Entities;

public class RefreshToken : BaseEntity
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiryTime { get; set; }
    public string CraftsmanId { get; set; }
    public virtual Craftsman Craftsman { get; set; } = null!;
}
