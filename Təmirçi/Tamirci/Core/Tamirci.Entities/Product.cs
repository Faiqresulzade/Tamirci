using Tamirci.Entities.Bases;

namespace Tamirci.Entities;

public class Product : BaseEntity, IHasCreateDate, IHasUpdateDate
{
    public string Name { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime CreateDate { get; set; }
}
