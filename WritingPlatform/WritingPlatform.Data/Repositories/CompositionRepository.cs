using System.Data.Entity;
using System.Linq;
using WritingPlatform.Data.Abstractions.Repositories;
using WritingPlatform.Data.Entities;

namespace WritingPlatform.Data.Repositories
{
    internal class CompositionRepository : Repository<Composition>, ICompositionRepository
    {

        public CompositionRepository(DbContext context) : base(context)
        {
        }

        public Composition GetByGenre(string genre)
        {
            return dbSet.First(work => work.Genre.Equals(genre));
        }

        public Composition GetByName(string name)
        {
            return dbSet.First(work => work.Name.Equals(name));
        }

        public Composition GetByUser(User user)
        {
            return dbSet.First(work => work.UserId.Equals(user.Id));
        }
    }
}
