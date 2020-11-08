using System.Data.Entity;
using System.Linq;
using WritingPlatform.Data.Abstractions.Repositories;
using WritingPlatform.Data.Entities;

namespace WritingPlatform.Data.Repositories
{
    internal class WorkRepository : Repository<Work>, IWorkRepository
    {

        public WorkRepository(DbContext context) : base(context)
        {
        }

        public Work GetByGenre(string genre)
        {
            return dbSet.First(work => work.Genre.Equals(genre));
        }

        public Work GetByName(string name)
        {
            return dbSet.First(work => work.Name.Equals(name));
        }

        public Work GetByUser(User user)
        {
            return dbSet.First(work => work.UserId.Equals(user.Id));
        }
    }
}
