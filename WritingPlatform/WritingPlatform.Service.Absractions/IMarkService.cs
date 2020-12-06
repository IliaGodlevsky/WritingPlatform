using System.Collections.Generic;
using WritingPlatform.Models.Mark;

namespace WritingPlatform.Service.Absractions
{
    public interface IMarkService
    {
        void AddMark(NewMarkModel mark);

        void RemoveMarkById(int id);

        void UpdateMark(UpdateMarkModel mark);

        MarkModel GetMarkById(int id);

        IEnumerable<MarkModel> GetMarks();
    }
}
