using InventoryManamegent.Domain.Validation;

namespace InventoryManamegent.Domain.Entities;

public class Product
{
    public int Id { get; private set; }
    public string Description { get; private set; }
    public bool Asset { get; private set; }
    public DateTime CreationAt { get; private set; }
    public DateTime ExpirationAt { get; private set; }
    public int CompanyId { get; set; }
    public Company? Company { get; set; }

    // Construtor criado apenas para popular dados em memória (SeedData).
    public Product(int id, string description, bool asset, DateTime creationAt, DateTime expirationAt, int companyId)
    {
        Id = id;
        Description = description;
        Asset = asset;
        CreationAt = creationAt;
        ExpirationAt = expirationAt;
        CompanyId = companyId;
        ValidateDomain();
    }

    public Product(string? description, bool? asset, DateTime? creationAt, DateTime? expirationAt, int? companyId)
    {
        Description = description ?? throw new ArgumentNullException(nameof(description));
        Asset = asset ?? throw new ArgumentNullException(nameof(asset));
        CreationAt = creationAt ?? throw new ArgumentNullException(nameof(creationAt));
        ExpirationAt = expirationAt ?? throw new ArgumentNullException(nameof(expirationAt));
        CompanyId = companyId ?? throw new ArgumentNullException(nameof(companyId));
        ValidateDomain();
    }

    public void Inactivate()
    {
        Asset = false;
    }

    public void ValidateDomain()
    {
        DomainExceptionValidation.When(Description.Length <= 3 || Description.Length > 50,
          "Description must be between 3 and 50 characters.");

        DomainExceptionValidation.When(CreationAt >= ExpirationAt,
            "Manufacturing date greater than or equal to expiration date.");
    }
}