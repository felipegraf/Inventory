using InventoryManamegent.Application.DTOs;

namespace InventoryManamegent.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProducts(
      int? pageNumber,
      int? pageSize,
      string? description = null,
      bool? asset = null,
      int? companyId = null);
    Task<ProductDTO> GetById(int id);
    Task Add(ProductDTO productDto);
    Task Update(ProductDTO productDto);
    Task Remove(int id);
}