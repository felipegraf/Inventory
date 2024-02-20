using InventoryManamegent.Domain.Entities;
using InventoryManamegent.Infra.Data.Context;

namespace InventoryManamegent.Infra.Data.Repositories;

public interface IDataSeeder
{
    void SeedData();
}
public class DataSeeder : IDataSeeder
{
    private readonly ApplicationDbContext _context;

    public DataSeeder(ApplicationDbContext context)
    {
        _context = context;
    }

    public void SeedData()
    {
        _context.Companies.AddRange(
            new Company(1, "Fornecedor 1", "12345678901231"),
            new Company(2, "Fornecedor 2", "12345678901232")
        );

       _context.Products.AddRange(
            new Product(1, "Produto 1", true, new DateTime(2024, 1, 1), new DateTime(2024, 1, 2), 1),
            new Product(2, "Produto 2", true, new DateTime(2024, 1, 2), new DateTime(2024, 1, 3), 2),
            new Product(3, "Produto 3", true, new DateTime(2024, 1, 3), new DateTime(2024, 1, 4), 1),
            new Product(4, "Produto 4", true, new DateTime(2024, 1, 4), new DateTime(2024, 1, 5), 2),
            new Product(5, "Produto 5", true, new DateTime(2024, 1, 5), new DateTime(2024, 1, 6), 1),
            new Product(6, "Produto 6", true, new DateTime(2024, 1, 6), new DateTime(2024, 1, 7), 2),
            new Product(7, "Produto 7", true, new DateTime(2024, 1, 7), new DateTime(2024, 1, 8), 1),
            new Product(8, "Produto 8", true, new DateTime(2024, 1, 8), new DateTime(2024, 1, 9), 2),
            new Product(9, "Produto 9", true, new DateTime(2024, 1, 9), new DateTime(2024, 1, 10), 1),
            new Product(10, "Produto 10", true, new DateTime(2024, 1, 10), new DateTime(2024, 1, 11), 2),
            new Product(11, "Produto 11", true, new DateTime(2024, 1, 11), new DateTime(2024, 1, 12), 1),
            new Product(12, "Produto 12", true, new DateTime(2024, 1, 12), new DateTime(2024, 1, 13), 2),
            new Product(13, "Produto 13", true, new DateTime(2024, 1, 13), new DateTime(2024, 1, 14), 1),
            new Product(14, "Produto 14", true, new DateTime(2024, 1, 14), new DateTime(2024, 1, 15), 2),
            new Product(15, "Produto 15", true, new DateTime(2024, 1, 15), new DateTime(2024, 1, 16), 1),
            new Product(16, "Produto 16", true, new DateTime(2024, 1, 16), new DateTime(2024, 1, 17), 2),
            new Product(17, "Produto 17", true, new DateTime(2024, 1, 17), new DateTime(2024, 1, 18), 1),
            new Product(18, "Produto 18", true, new DateTime(2024, 1, 18), new DateTime(2024, 1, 19), 2),
            new Product(19, "Produto 19", true, new DateTime(2024, 1, 19), new DateTime(2024, 1, 20), 1),
            new Product(20, "Produto 20", true, new DateTime(2024, 1, 20), new DateTime(2024, 1, 21), 2)
        );

        _context.SaveChanges();
    }
}