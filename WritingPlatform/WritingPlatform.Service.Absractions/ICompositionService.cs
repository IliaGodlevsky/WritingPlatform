using System;
using System.Collections.Generic;
using WritingPlatform.Models.Compositions;

namespace WritingPlatform.Service.Absractions
{
    public interface ICompositionService
    {
        void AddComposition(NewCompositionModel work);

        void RemoveCompositionById(int id);

        void UpdateComposition(UpdateCompositionModel work);

        CompositionModel GetCompositionById(int id);

        CompositionModel GetCompositionBy(Func<CompositionModel, bool> selector);

        IEnumerable<CompositionModel> GetCompositions();

    }
}
