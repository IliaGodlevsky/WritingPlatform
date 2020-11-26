using System.Collections.Generic;
using System.Linq;
using WritingPlatform.Data.Abstractions;
using WritingPlatform.Data.Entities;
using WritingPlatform.Models;
using WritingPlatform.Models.Comments;
using WritingPlatform.Models.Compositions;
using WritingPlatform.Models.Identity;
using WritingPlatform.Models.Users;
using WritingPlatform.Service.Absractions;
using WritingPlatform.Service.Mapping;

namespace WritingPlatform.Service
{
    public class UserService : IUserService
    {
        private readonly IDataUnitOfWork uow;

        public UserService(IDataUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void AddUser(NewUserModel user)
        {
            var entity = MapperService.Instance.Map<NewUserModel, User>(user);
            uow.UserRepository.Create(entity);

            uow.Commit();
        }

        public UserModel GetByCredentials(Credentials creds)
        {
            var entity = uow.UserRepository.GetAll().
                FirstOrDefault(u => u.Login == creds.Login && u.Password == creds.Password && !u.IsDeleted);
            var model = MapperService.Instance.Map<User, UserModel>(entity);

            return model;
        }

        public UserModel GetById(int id)
        {
            var entity = uow.UserRepository.GetById(id);
            var model = MapperService.Instance.Map<User, UserModel>(entity);

            return model;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            var entities = uow.UserRepository.GetAll();
            var models = MapperService.Instance.Map<IEnumerable<UserModel>>(entities);

            return models;
        }

        public IEnumerable<UserWithCompositionsModel> GetUsersWithCompositions()
        {
            var compositionEntities = uow.CompositionRepository.GetAll();
            var commentEntities = uow.CommentRepository.GetAll();
            var userEntities = uow.UserRepository.GetAll();

            var compositionsWithComments = compositionEntities.GroupJoin(
                commentEntities,
                composition => composition.Id, 
                comment => comment.WorkId,
                (composition, comments) =>
                {
                    var compositionModel = MapperService.Instance.Map<Composition, CompositionWithCommentsModel>(composition);
                    var commentModels = MapperService.Instance.Map<IEnumerable<CommentModel>>(comments);
                    compositionModel.Comments = commentModels;
                    return compositionModel;
                });

            var usersWithCompositions = userEntities.GroupJoin(
                compositionsWithComments,
                userEntity => userEntity.Id,
                compositionWithComments => compositionWithComments.UserId,
                (userEntity, compositions) =>
                {
                    var userModel = MapperService.Instance.Map<User, UserWithCompositionsModel>(userEntity);
                    userModel.Compositions = compositions;
                    return userModel;
                });

            return usersWithCompositions;
        }

        public void RemoveUserById(int id)
        {
            var user = uow.UserRepository.GetById(id);
            uow.UserRepository.Remove(user);
            uow.Commit();
        }

        public void UpdateUser(UserModel user)
        {
            var entity = MapperService.Instance.Map<UserModel, User>(user);
            uow.UserRepository.Update(entity);

            uow.Commit();
        }
    }
}
