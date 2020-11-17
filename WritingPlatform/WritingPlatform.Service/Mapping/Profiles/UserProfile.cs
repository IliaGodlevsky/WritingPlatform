using AutoMapper;
using WritingPlatform.Data.Entities;
using WritingPlatform.Models.Users;

namespace WritingPlatform.Service.Mapping.Profiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<NewUserModel, User>();
        }
    }
}
