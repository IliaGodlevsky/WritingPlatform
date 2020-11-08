using System.Collections.Generic;
using WritingPlatform.Data.Entities;

namespace WritingPlatform.Service.Absractions
{
    public interface IWorkService
    {
        void AddWork(Work work);

        void RemoveUserById(int id);

        void UpdateWork(Work work);

        Work GetById(int id);

        IEnumerable<Work> GetWorks();
    }
}
