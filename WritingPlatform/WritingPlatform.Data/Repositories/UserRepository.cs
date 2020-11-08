using System.Data.Entity;
using WritingPlatform.Data.Abstractions.Repositories;
using WritingPlatform.Data.Entities;

namespace WritingPlatform.Data.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {

        }
    }
}
