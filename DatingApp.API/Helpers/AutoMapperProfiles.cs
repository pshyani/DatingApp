using System.Linq;
using AutoMapper;
using DatingApp.API.DTO;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Users, UserForListDTO>()
                .ForMember(dest => dest.PhotoUrl, opt => 
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain.GetValueOrDefault(true)).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom( src => src.DateOfBirth.GetValueOrDefault().CalculateAge() ));
            CreateMap<Users, UserForDetailsDTO>()
                .ForMember(dest => dest.PhotoUrl, opt => 
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain.GetValueOrDefault(true)).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom( src => src.DateOfBirth.GetValueOrDefault().CalculateAge() ));
            CreateMap<Photos, PhotoesForDetailsDTO>();
        }
        
    }
} 