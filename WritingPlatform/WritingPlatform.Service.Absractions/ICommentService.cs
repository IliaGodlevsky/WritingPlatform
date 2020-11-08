using System.Collections.Generic;
using WritingPlatform.Data.Entities;

namespace WritingPlatform.Service.Absractions
{
    public interface ICommentService
    {
        void AddComment(Comment comment);

        void RemoveCommentById(int id);

        void UpdateComment(Comment comment);

        Comment GetById(int id);

        IEnumerable<Comment> GetUsers();
    }
}
