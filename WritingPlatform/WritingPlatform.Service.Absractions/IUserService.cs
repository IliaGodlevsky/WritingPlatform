using System.Collections.Generic;
using WritingPlatform.Models;
using WritingPlatform.Models.Identity;
using WritingPlatform.Models.Users;

namespace WritingPlatform.Service.Absractions
{
    public interface IUserService
    {
        void AddUser(NewUserModel user);

        void RemoveUserById(int id);

        void UpdateUser(UpdateUserModel user);

        UserModel GetById(int id);

        UserModel GetByCredentials(Credentials creds);

        IEnumerable<UserWithCompositionsModel> GetUsersWithCompositions();

        IEnumerable<UserModel> GetUsers();
    }
}
