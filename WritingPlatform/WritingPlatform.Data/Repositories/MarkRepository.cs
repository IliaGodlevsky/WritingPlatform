using System.Data.Entity;
using WritingPlatform.Data.Abstractions.Repositories;
using WritingPlatform.Data.Entities;

namespace WritingPlatform.Data.Repositories
{
    internal class MarkRepository : Repository<Mark>, IMarkRepository
    {
        public MarkRepository(DbContext context) : base(context)
        {

        }
    }
}
