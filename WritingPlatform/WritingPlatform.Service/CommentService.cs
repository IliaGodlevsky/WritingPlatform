using System.Collections.Generic;
using WritingPlatform.Data.Abstractions;
using WritingPlatform.Data.Entities;
using WritingPlatform.Models.Comments;
using WritingPlatform.Service.Absractions;
using WritingPlatform.Service.Mapping;

namespace WritingPlatform.Service
{
    public class CommentService : ICommentService
    {
        private readonly IDataUnitOfWork uow;

        public CommentService(IDataUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void AddComment(NewCommentModel comment)
        {
            var entity = MapperService.Instance.Map<NewCommentModel, Comment>(comment);

            uow.CommentRepository.Create(entity);
            uow.Commit();
        }

        public CommentModel GetById(int id)
        {
            var entity = uow.CommentRepository.GetById(id);
            var model = MapperService.Instance.Map<Comment, CommentModel>(entity);

            return model;
        }

        public IEnumerable<CommentModel> GetComments()
        {
            var entities = uow.UserRepository.GetAll();
            var models = MapperService.Instance.Map<IEnumerable<CommentModel>>(entities);

            return models;
        }

        public void RemoveCommentById(int id)
        {
            var comment = uow.CommentRepository.GetById(id);
            uow.CommentRepository.Remove(comment);

            uow.Commit();
        }
    }
}
