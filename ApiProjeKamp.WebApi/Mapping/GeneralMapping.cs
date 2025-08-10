using ApiProjeKamp.WebApi.DTOs.AboutDTOs;
using ApiProjeKamp.WebApi.DTOs.CategoryDTO;
using ApiProjeKamp.WebApi.DTOs.ContactDTOs;
using ApiProjeKamp.WebApi.DTOs.FeatureDTOs;
using ApiProjeKamp.WebApi.DTOs.MessageDTOs;
using ApiProjeKamp.WebApi.DTOs.NotificationDTOs;
using ApiProjeKamp.WebApi.DTOs.ProductDTOs;
using ApiProjeKamp.WebApi.DTOs.TestimonialDTOs;
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

            CreateMap<Contact, ResultContactDTO>().ReverseMap();
            CreateMap<Contact, GetByIDContactDTO>().ReverseMap();
            CreateMap<Contact, CreateContactDTO>().ReverseMap();
            CreateMap<Contact, UpdateContactDTO>().ReverseMap();

            CreateMap<Notification, ResultNotificationDTO>().ReverseMap();
            CreateMap<Notification, GetNotificationByIDDTO>().ReverseMap();
            CreateMap<Notification, CreateNotificationDTO>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDTO>().ReverseMap();

            CreateMap<About, ResultAboutDTO>().ReverseMap();
            CreateMap<About, CreateAboutDTO>().ReverseMap();
            CreateMap<About, UpdateAboutDTO>().ReverseMap();
            CreateMap<About, GetAboutByIDDTO>().ReverseMap();

            CreateMap<Testimonial, ResultTestimonialDTO>().ReverseMap();

            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();

            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDTO>().ForMember(x=>x.CategoryName, y=>y.MapFrom(z=>z.Category.CategoryName)).ReverseMap();
            
        }
    }
}
