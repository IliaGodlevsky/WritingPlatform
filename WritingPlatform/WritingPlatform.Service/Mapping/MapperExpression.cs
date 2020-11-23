using AutoMapper.Configuration;
using WritingPlatform.Service.Mapping.Profiles;

namespace WritingPlatform.Service.Mapping
{
    internal class MapperExpression : MapperConfigurationExpression
    {
        public MapperExpression()
        {
            AddProfile<UserProfile>();
            AddProfile<CommentProfile>();
            AddProfile<CompositionProfile>();
        }
    }
}
