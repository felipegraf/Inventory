using InventoryManamegent.Domain.Entities;
using InventoryManamegent.Domain.Validation;

namespace InventoryManamegent.Domain.Test.EntitiesTest;

public class ProductTest
{
    [Fact]
    public void MustInstantiateModel_Success()
    {
        // Arrange & Act
        var product = new Product("teste", true, DateTime.Now, DateTime.Now.AddHours(1), 1);

        // Assert
        Assert.NotNull(product);
    }

    [Fact]
    public void MustInstantiateModel_WithCreationDateGreaterThanExpiration()
    {
        // Arrange, Assert & Act
        Assert.Throws<DomainExceptionValidation>(() => 
            new Product("teste", true, DateTime.Now.AddHours(1), DateTime.Now, 1));
    }
}
