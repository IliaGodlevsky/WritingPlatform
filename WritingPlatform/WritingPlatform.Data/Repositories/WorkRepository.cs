using System.Data.Entity;
using WritingPlatform.Data.Abstractions.Repositories;
using WritingPlatform.Data.Entities;

namespace WritingPlatform.Data.Repositories
{
    internal class WorkRepository : Repository<Work>, IWorkRepository
    {
        public WorkRepository(DbContext context) : base(context)
        {
        }
    }
}
