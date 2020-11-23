using System;
using System.Collections.Generic;
using WritingPlatform.Models.Compositions;

namespace WritingPlatform.Service.Absractions
{
    public interface ICompositionService
    {
        void AddWork(NewCompositionModel work);

        void RemoveUserById(int id);

        void UpdateWork(UpdateCompositionkModel work);

        CompositionModel GetById(int id);

        CompositionModel GetBy(Func<CompositionModel, bool> selector);

        IEnumerable<CompositionModel> GetWorks();


    }
}
