using System;
using System.Collections.Generic;
using WritingPlatform.Models.Works;

namespace WritingPlatform.Service.Absractions
{
    public interface IWorkService
    {
        void AddWork(NewWorkModel work);

        void RemoveUserById(int id);

        void UpdateWork(UpdateWorkModel work);

        WorkModel GetById(int id);

        WorkModel GetBy(Func<WorkModel, bool> selector);

        IEnumerable<WorkModel> GetWorks();


    }
}
