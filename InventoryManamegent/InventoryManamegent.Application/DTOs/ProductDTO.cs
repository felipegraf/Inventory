using InventoryManamegent.Application.Utils;

namespace InventoryManamegent.Application.DTOs;

public class ProductDTO
{
    public int? Id { get; set; }
    public required string Description { get; set; }
    public bool Asset { get; set; }
    public required DateTime CreationAt { get; set; }
    public required DateTime? ExpirationAt { get; set; }
    public required int CompanyId { get; set; }
    public CompanyDTO? Company { get; set; }


    public override int GetHashCode()
    {
        return DTOHelper.GetHashCodeHelper(this);
    }

    public override bool Equals(object? obj)
    {
        return obj is ProductDTO other && DTOHelper.EqualsHelper(this, other);
    }
}
