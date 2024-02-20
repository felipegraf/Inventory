using InventoryManamegent.Domain.Validation;

namespace InventoryManamegent.Domain.Entities;

public class Company
{
    public int Id { get; private set; }
    public string Description { get; private set; }
    public string Cnpj { get; private set; }

    // Construtor criado apenas para popular dados em memória (SeedData).
    public Company(int id, string? description, string? cnpj)
    {
        Id = id;
        Description = description ?? throw new ArgumentNullException(nameof(description));
        Cnpj = cnpj ?? throw new ArgumentNullException(nameof(cnpj));
        ValidateDomain();
    }

    public Company(string? description, string? cnpj)
    {
        Description = description ?? throw new ArgumentNullException(nameof(description));
        Cnpj = cnpj ?? throw new ArgumentNullException(nameof(cnpj));
        ValidateDomain();
    }

    public void ValidateDomain()
    {
        DomainExceptionValidation.When(Description.Length <= 3 || Description.Length > 50,
            "Description must be between 3 and 50 characters.");

        DomainExceptionValidation.When(Cnpj.Length != 14,
            "Cnpj must have 14 characters.");
    }
}
