﻿using ApiProjeKamp.WebApi.DTOs.FeatureDTOs;
using ApiProjeKamp.WebApi.DTOs.MessageDTOs;
using ApiProjeKamp.WebApi.DTOs.ProductDTOs;
using ApiProjeKamp.WebApi.Entities;
using AutoMapper;

namespace ApiProjeKamp.WebApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping() 
        {
            CreateMap<Feature, ResultFeatureDTO>().ReverseMap();  
            CreateMap<Feature, UpdateFeatureDTO>().ReverseMap();  
            CreateMap<Feature, CreateFeatureDTO>().ReverseMap();  
            CreateMap<Feature, GetByIDFeatureDTO>().ReverseMap();

            CreateMap<Message, ResultMessageDTO>().ReverseMap();
            CreateMap<Message, UpdateMessageDTO>().ReverseMap();
            CreateMap<Message, CreateMessageDTO>().ReverseMap();
            CreateMap<Message, GetByIDMessageDTO>().ReverseMap();

            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDTO>().ForMember(x=>x.CategoryName, y=>y.MapFrom(z=>z.Category.CategoryName)).ReverseMap();
            
        }
    }
}
