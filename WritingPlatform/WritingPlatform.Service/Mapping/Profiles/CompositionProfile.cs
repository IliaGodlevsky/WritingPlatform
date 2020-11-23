﻿using AutoMapper;
using WritingPlatform.Data.Entities;
using WritingPlatform.Models.Compositions;

namespace WritingPlatform.Service.Mapping.Profiles
{
    internal class CompositionProfile : Profile
    {
        public CompositionProfile()
        {
            CreateMap<CompositionModel, Composition>();
            CreateMap<Composition, CompositionModel>();
            CreateMap<NewCompositionModel, Composition>();
            CreateMap<UpdateCompositionkModel, Composition>();
            CreateMap<CompositionWithCommentsModel, Composition>();
        }
    }
}