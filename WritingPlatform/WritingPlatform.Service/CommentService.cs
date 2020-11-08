using System.Collections.Generic;
using WritingPlatform.Data.Abstractions;
using WritingPlatform.Data.Entities;
using WritingPlatform.Service.Absractions;

namespace WritingPlatform.Service
{
    public class CommentService : ICommentService
    {
        private readonly IDataUnitOfWork uow;

        public CommentService(IDataUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void AddComment(Comment comment)
        {
            uow.CommentRepository.Create(comment);
            uow.Commit();
        }

        public Comment GetById(int id)
        {
            return uow.CommentRepository.GetById(id);
        }

        public IEnumerable<Comment> GetUsers()
        {
            return uow.CommentRepository.GetAll();
        }

        public void RemoveCommentById(int id)
        {
            var comment = uow.CommentRepository.GetById(id);
            uow.CommentRepository.Remove(comment);
            uow.Commit();
        }

        public void UpdateComment(Comment comment)
        {
            uow.CommentRepository.Update(comment);
            uow.Commit();
        }
    }
}
