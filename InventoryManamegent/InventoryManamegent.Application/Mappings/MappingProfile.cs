using AutoMapper;
using InventoryManamegent.Application.DTOs;
using InventoryManamegent.Domain.Entities;

namespace InventoryManamegent.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO, Product>().ConstructUsing(dto => new Product(dto.Description, dto.Asset, dto.CreationAt, dto.ExpirationAt, dto.CompanyId));
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Company, CompanyDTO>().ReverseMap();
        }
    }
}