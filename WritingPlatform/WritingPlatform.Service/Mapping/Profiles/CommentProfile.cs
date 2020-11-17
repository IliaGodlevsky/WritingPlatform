using AutoMapper;
using WritingPlatform.Data.Entities;
using WritingPlatform.Models.Comments;

namespace WritingPlatform.Service.Mapping.Profiles
{
    internal class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentModel>();
            CreateMap<CommentModel, Comment>();
            CreateMap<NewCommentModel, Comment>();
        }
    }
}
