using InventoryManamegent.Domain.Entities;

namespace InventoryManamegent.Application.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync(
     int? pageNumber,
     int? pageSize,
     string? description = null,
     bool? asset = null,
     int? companyId = null);
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task<Product> RemoveAsync(Product product);
}
