using AutoMapper;
using WritingPlatform.Data.Entities;
using WritingPlatform.Models.Mark;

namespace WritingPlatform.Service.Mapping.Profiles
{
    internal class MarkProfile : Profile
    {
        public MarkProfile()
        {
            CreateMap<Mark, MarkModel>();
            CreateMap<MarkModel, Mark>();
            CreateMap<NewMarkModel, Mark>();
            CreateMap<Mark, NewMarkModel>();
            CreateMap<Mark, UpdateMarkModel>();
            CreateMap<UpdateMarkModel, Mark>();
        }
    }
}
