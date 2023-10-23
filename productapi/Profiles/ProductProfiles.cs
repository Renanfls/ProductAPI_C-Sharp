using AutoMapper;
using ProductApi.Data.Dtos;
using ProductApi.Models;

namespace ProductApi.Profiles;

public class ProductProfile : Profile
{
  public ProductProfile()
  {
    CreateMap<CreateProductDto, Product>();
    CreateMap<UpdateProductDto, Product>();
  }
}