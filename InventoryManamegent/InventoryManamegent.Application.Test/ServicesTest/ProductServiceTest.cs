using AutoMapper;
using InventoryManamegent.Application.DTOs;
using InventoryManamegent.Application.Interfaces;
using InventoryManamegent.Application.Services;
using InventoryManamegent.Domain.Entities;
using Moq;

namespace InventoryManamegent.Application.Test.ServicesTest;

public class ProductServiceTest
{
    private Mock<IProductRepository> _productRepositoryMock;
    private Mock<IMapper> _mapperMock;
    public ProductServiceTest()
    {
        _productRepositoryMock = new();
        _mapperMock = new();
    }

    #region GetByIdTest
    [Fact]
    public async void GetById_ReturnProduct_Success()
    {
        // Arrange
        var id = 10;
        var productEntity = new Product("descriptionTest", true, DateTime.Now, DateTime.Now.AddDays(2), 1);
        var productDTO = new ProductDTO
        {
            Description = productEntity.Description,
            CompanyId = productEntity.CompanyId,
            CreationAt = productEntity.CreationAt,
            ExpirationAt = productEntity.ExpirationAt,
            Asset = productEntity.Asset,
        };

        _productRepositoryMock
            .Setup(c => c.GetByIdAsync(id))
            .ReturnsAsync(productEntity);

        _mapperMock
            .Setup(mapper => mapper.Map<ProductDTO>(productEntity))
            .Returns(productDTO);

        var productService = new ProductService(_productRepositoryMock.Object, _mapperMock.Object);

        // Act
        var res = await productService.GetById(id);

        // Assert
        Assert.Equal(productDTO, res);
    }

    [Fact]
    public async void GetById_ReturnProduct_Exception()
    {
        // Arrange
        var id = 10;
        Product? product = null;

        _productRepositoryMock
            .Setup(c => c.GetByIdAsync(id))
            .ReturnsAsync(product);

        var productService = new ProductService(_productRepositoryMock.Object, _mapperMock.Object);

        // Act && Assert
        await Assert.ThrowsAsync<Exception>(async () => await productService.GetById(id));
    }
    #endregion
}