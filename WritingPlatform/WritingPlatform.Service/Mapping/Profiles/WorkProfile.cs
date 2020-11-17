using AutoMapper;
using WritingPlatform.Data.Entities;
using WritingPlatform.Models.Works;

namespace WritingPlatform.Service.Mapping.Profiles
{
    internal class WorkProfile : Profile
    {
        public WorkProfile()
        {
            CreateMap<WorkModel, Work>();
            CreateMap<Work, WorkModel>();
            CreateMap<NewWorkModel, Work>();
        }
    }
}
