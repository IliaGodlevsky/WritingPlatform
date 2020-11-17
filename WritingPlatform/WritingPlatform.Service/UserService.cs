using System.Collections.Generic;
using WritingPlatform.Data.Abstractions;
using WritingPlatform.Data.Entities;
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

        public void RemoveUserById(int id)
        {
            var user = uow.UserRepository.GetById(id);
            uow.UserRepository.Remove(user);
            uow.Commit();
        }

        public void UpdateUser(UpdateUserModel user)
        {
            var entity = MapperService.Instance.Map<UpdateUserModel, User>(user);
            uow.UserRepository.Update(entity);

            uow.Commit();
        }
    }
}
