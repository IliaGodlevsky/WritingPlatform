using WritingPlatform.Base.Abstractions;
using WritingPlatform.Data.Entities;

namespace WritingPlatform.Data.Abstractions.Repositories
{
    public interface IWorkRepository : IRepository<Work>
    {
        Work GetByName(string name);
        Work GetByUser(User user);
        Work GetByGenre(string genre);
    }
}
