using System.Collections.Generic;
using WritingPlatform.Data.Entities;

namespace WritingPlatform.Service.Absractions
{
    public interface IUserService
    {
        void AddUser(User user);

        void RemoveUserById(int id);

        void UpdateUser(User user);

        User GetById(int id);

        IEnumerable<User> GetUsers();
    }
}
