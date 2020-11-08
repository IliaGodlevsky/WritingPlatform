using System.Collections.Generic;
using WritingPlatform.Data.Abstractions;
using WritingPlatform.Data.Entities;
using WritingPlatform.Service.Absractions;

namespace WritingPlatform.Service
{
    public class UserService : IUserService
    {
        private readonly IDataUnitOfWork uow;

        public UserService(IDataUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void AddUser(User user)
        {
            uow.UserRepository.Create(user);
            uow.Commit();
        }

        public User GetById(int id)
        {
            return uow.UserRepository.GetById(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return uow.UserRepository.GetAll();
        }

        public void RemoveUserById(int id)
        {
            var user = uow.UserRepository.GetById(id);
            uow.UserRepository.Remove(user);
            uow.Commit();
        }

        public void UpdateUser(User user)
        {
            uow.UserRepository.Update(user);
            uow.Commit();
        }
    }
}
