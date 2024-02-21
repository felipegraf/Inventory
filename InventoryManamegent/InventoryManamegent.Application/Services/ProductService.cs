using AutoMapper;
using InventoryManamegent.Application.DTOs;
using InventoryManamegent.Application.Interfaces;
using InventoryManamegent.Domain.Entities;

namespace InventoryManamegent.Application.Services;

public class ProductService : IProductService
{
    private IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts(
      int? pageNumber,
      int? pageSize,
      string? description = null,
      bool? asset = null,
      int? companyId = null)
    {
        try
        {
            var prodctsEntity = await _productRepository.GetAllAsync(
                pageNumber,
                pageSize,
                description,
                asset,
                companyId);

            return _mapper.Map<IEnumerable<ProductDTO>>(prodctsEntity);
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to get products. {ex.Message}");
        }
    }

    public async Task<ProductDTO> GetById(int id)
    {
        try
        {
            var productEntity = await _productRepository.GetByIdAsync(id) ?? throw new Exception("Product not found.");
            return _mapper.Map<ProductDTO>(productEntity);
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to get product by id. {ex.Message}");
        }
    }

    public async Task Add(ProductDTO productDto)
    {
        try
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.CreateAsync(productEntity);
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to add product. {ex.Message}");
        }
    }

    public async Task Update(ProductDTO productDto)
    {
        try
        {
            var id = productDto.Id ?? throw new InvalidOperationException("Id invalid.");
            var productEntity = await _productRepository.GetByIdAsync(id) ?? throw new InvalidOperationException("Product not found.");

            _mapper.Map(productDto, productEntity);
            productEntity.ValidateDomain();
            await _productRepository.UpdateAsync(productEntity);
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to update product. {ex.Message}");
        }
    }

    public async Task Remove(int id)
    {
        try
        {
            var productEntity = await _productRepository.GetByIdAsync(id) ?? throw new Exception("Product not found.");
            await _productRepository.RemoveAsync(productEntity);
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to remove product. {ex.Message}");
        }
    }
}