using System.Collections.Generic;
using WritingPlatform.Models.Comments;

namespace WritingPlatform.Service.Absractions
{
    public interface ICommentService
    {
        void AddComment(NewCommentModel comment);

        void RemoveCommentById(int id);

        CommentModel GetById(int id);

        IEnumerable<CommentModel> GetComments();
    }
}
