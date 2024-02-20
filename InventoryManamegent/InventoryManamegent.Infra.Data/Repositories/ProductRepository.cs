using InventoryManamegent.Application.Interfaces;
using InventoryManamegent.Domain.Entities;
using InventoryManamegent.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InventoryManamegent.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _productContext;
    public ProductRepository(ApplicationDbContext context)
    {
        _productContext = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync(
     int? pageNumber,
     int? pageSize,
     string? description = null,
     bool? asset = null,
     int? companyId = null)
    {
        var number =  pageNumber ?? 1;
        var size = pageSize ?? 1;

        var query = _productContext.Products
            .Include(c => c.Company)
            .OrderBy(p => p.Id)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(description))
            query = query.Where(p => p.Description.Contains(description));

        if (asset.HasValue)
            query = query.Where(p => p.Asset == asset);

        if (companyId.HasValue)
            query = query.Where(p => p.CompanyId == companyId);

        return await query.Skip((number - 1) * size).Take(size).ToListAsync();
    }
    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _productContext.Products.Include(c => c.Company)
           .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product> CreateAsync(Product product)
    {
        _productContext.Add(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        _productContext.Entry(product).State = EntityState.Modified;
        await _productContext.SaveChangesAsync();
        return product;
    }
    public async Task<Product> RemoveAsync(Product product)
    {
        product.Inactivate();
        return await UpdateAsync(product);
    }
}