using WritingPlatform.Base.Abstractions;
using WritingPlatform.Data.Entities;

namespace WritingPlatform.Data.Abstractions.Repositories
{
    public interface ICompositionRepository : IRepository<Composition>
    {
        Composition GetByName(string name);
        Composition GetByUser(User user);
        Composition GetByGenre(string genre);
    }
}
