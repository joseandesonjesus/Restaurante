using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProjectFood.Application.Dtos;
using ProjectFood.Domain;
using ProjectFood.Domain.Identity;

namespace ProjectFood.Application.Helpers
{
    public class ProjectFoodProfile : Profile
    {
     public ProjectFoodProfile()
     {
         CreateMap<Product, ProductDto>().ReverseMap();
         CreateMap<Category, CategoryDto>().ReverseMap();
         //CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
         CreateMap<ProductImage, ProductImageDto>().ReverseMap();
         CreateMap<User, UserDto>().ReverseMap();
         CreateMap<User, UserLoginDto>().ReverseMap();
         CreateMap<User, UserUpdateDto>().ReverseMap();
         CreateMap<Images, ImagesDto>().ReverseMap();
         CreateMap<Title, TitleDto>().ReverseMap();
         CreateMap<Function, FunctionDto>().ReverseMap();
         CreateMap<InTable, InTableDto>().ReverseMap();
         CreateMap<BulkProduct, BulkProductDto>().ReverseMap();
         CreateMap<OrdersTable, OrdersTableDto>().ReverseMap();
         
     }   
    }
}