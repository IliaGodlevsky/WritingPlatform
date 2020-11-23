using System;
using System.Collections.Generic;
using System.Linq;
using WritingPlatform.Data.Abstractions;
using WritingPlatform.Data.Entities;
using WritingPlatform.Models.Compositions;
using WritingPlatform.Service.Absractions;
using WritingPlatform.Service.Mapping;

namespace WritingPlatform.Service
{
    public class CompositionService : ICompositionService
    {
        private readonly IDataUnitOfWork uow;

        public CompositionService(IDataUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void AddWork(NewCompositionModel work)
        {
            var entity = MapperService.Instance.Map<NewCompositionModel, Composition>(work);
            uow.CompositionRepository.Create(entity);

            uow.Commit();
        }

        public CompositionModel GetBy(Func<CompositionModel, bool> selector)
        {
            var entities = uow.CompositionRepository.GetAll();
            var models = MapperService.Instance.Map<IEnumerable<CompositionModel>>(entities);

            var filteredModel = models.FirstOrDefault(selector);
            return filteredModel;
        }

        public CompositionModel GetById(int id)
        {
            var entity = uow.CompositionRepository.GetById(id);
            var model = MapperService.Instance.Map<Composition, CompositionModel>(entity);

            return model;
        }

        public IEnumerable<CompositionModel> GetWorks()
        {
            var entities = uow.CompositionRepository.GetAll();
            var models = MapperService.Instance.Map<IEnumerable<CompositionModel>>(entities);

            return models;
        }

        public void RemoveUserById(int id)
        {
            var work = uow.CompositionRepository.GetById(id);
            uow.CompositionRepository.Remove(work);

            uow.Commit();
        }

        public void UpdateWork(UpdateCompositionkModel work)
        {
            var entity = MapperService.Instance.Map<UpdateCompositionkModel, Composition>(work);
            uow.CompositionRepository.Update(entity);

            uow.Commit();
        }
    }
}
