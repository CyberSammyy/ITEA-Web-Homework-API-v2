using AutoMapper;
using BusinessLogic.Classes;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace BusinessLogic
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //From User to UserDTO
            CreateMap<UserDTO, User>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.Nickname, opt => opt.MapFrom(src => src.Nickname))
                .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.PasswordHash.GetMD5Hash()))
                .ForMember(dst => dst.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));

            //From UserDTO to User
            CreateMap<User, UserDTO>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.Nickname, opt => opt.MapFrom(src => src.Nickname))
                .ForMember(dst => dst.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ForMember(dst => dst.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
        }
    }
}
