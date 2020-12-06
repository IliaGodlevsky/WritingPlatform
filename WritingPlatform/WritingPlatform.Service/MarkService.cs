using System.Collections.Generic;
using WritingPlatform.Data.Abstractions;
using WritingPlatform.Data.Entities;
using WritingPlatform.Models.Mark;
using WritingPlatform.Service.Absractions;
using WritingPlatform.Service.Mapping;

namespace WritingPlatform.Service
{
    public class MarkService : IMarkService
    {
        private readonly IDataUnitOfWork uow;

        public MarkService(IDataUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void AddMark(NewMarkModel work)
        {
            var entity = MapperService.Instance.Map<NewMarkModel, Mark>(work);
            uow.MarkRepository.Create(entity);

            uow.Commit();
        }

        public MarkModel GetMarkById(int id)
        {
            var entity = uow.MarkRepository.GetById(id);
            var model = MapperService.Instance.Map<Mark, MarkModel>(entity);

            return model;
        }

        public IEnumerable<MarkModel> GetMarks()
        {
            var entities = uow.MarkRepository.GetAll();
            var models = MapperService.Instance.Map<IEnumerable<MarkModel>>(entities);

            return models;
        }

        public void RemoveMarkById(int id)
        {
            var work = uow.MarkRepository.GetById(id);
            uow.MarkRepository.Remove(work);

            uow.Commit();
        }

        public void UpdateMark(UpdateMarkModel work)
        {
            var entity = MapperService.Instance.Map<UpdateMarkModel, Mark>(work);
            uow.MarkRepository.Update(entity);

            uow.Commit();
        }
    }
}
