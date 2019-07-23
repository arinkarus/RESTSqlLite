using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using RESTSqLite.BLL.Interface.Models;

namespace RESTSqLite.BLL.Interface.MapperProfiles
{
    public class PostMappingProfile : Profile 
    {
        public PostMappingProfile()
        {
            CreateMap<UpdatePostRequest, RESTSqLite.DAL.Models.Post>();

            CreateMap<Interface.Models.Post, RESTSqLite.DAL.Models.Post>()
                .ForMember(vm => vm.Id, map => map.MapFrom(m => m.Id))
                .ForMember(vm => vm.SubTitle, map => map.MapFrom(m => m.SubTitle))
                .ForMember(vm => vm.Text, map => map.MapFrom(m => m.FullText))
                .ForMember(vm => vm.Title, map => map.MapFrom(m => m.Title));
                
            CreateMap<RESTSqLite.DAL.Models.Post, Interface.Models.Post>()
                .ForMember(vm => vm.Id, map => map.MapFrom(m => m.Id))
                .ForMember(vm => vm.SubTitle, map => map.MapFrom(m => m.SubTitle))
                .ForMember(vm => vm.FullText, map => map.MapFrom(m => m.Text))
                .ForMember(vm => vm.Title, map => map.MapFrom(m => m.Title)); 
            
           
        }
    }
}
