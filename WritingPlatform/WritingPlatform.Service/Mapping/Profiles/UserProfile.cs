using AutoMapper;
using WritingPlatform.Data.Entities;
using WritingPlatform.Models;
using WritingPlatform.Models.Users;

namespace WritingPlatform.Service.Mapping.Profiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<User, UserWithCompositionsModel>();
            CreateMap<UserModel, User>();
            CreateMap<NewUserModel, User>();
        }
    }
}
