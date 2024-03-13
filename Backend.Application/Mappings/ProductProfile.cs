using Backend.Application.Features.Products.Commands.Create;
using Backend.Application.Features.Products.Queries.GetAllCached;
using Backend.Application.Features.Products.Queries.GetAllPaged;
using Backend.Application.Features.Products.Queries.GetById;
using Backend.Domain.Entities.Catalog;
using AutoMapper;

namespace Backend.Application.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<GetProductByIdResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsCachedResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsResponse, Product>().ReverseMap();
        }
    }
}