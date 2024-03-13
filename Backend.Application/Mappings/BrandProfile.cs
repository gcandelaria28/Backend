using Backend.Application.Features.Brands.Commands.Create;
using Backend.Application.Features.Brands.Queries.GetAllCached;
using Backend.Application.Features.Brands.Queries.GetById;
using Backend.Domain.Entities.Catalog;
using AutoMapper;

namespace Backend.Application.Mappings
{
    internal class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<CreateBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsCachedResponse, Brand>().ReverseMap();
        }
    }
}