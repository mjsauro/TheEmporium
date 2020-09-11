using AutoMapper;
using TheEmporium.Models;
using TheEmporium.Models.DTOs;

namespace TheEmporium
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductType, ProductTypeDto>();
            CreateMap<ProductTypeDto, ProductType>();
            CreateMap<ShoppingCart, ShoppingCartDto>();
            CreateMap<ShoppingCartDto, ShoppingCart>();
        }
    }
}