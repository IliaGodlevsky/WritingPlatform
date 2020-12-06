using System;
using System.Collections.Generic;
using System.Linq;
using WritingPlatform.Data.Abstractions;
using WritingPlatform.Data.Entities;
using WritingPlatform.Models.Comments;
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

        public void AddComposition(NewCompositionModel work)
        {
            var entity = MapperService.Instance.Map<NewCompositionModel, Composition>(work);
            uow.CompositionRepository.Create(entity);

            uow.Commit();
        }

        public CompositionModel GetCompositionBy(Func<CompositionModel, bool> selector)
        {
            var entities = uow.CompositionRepository.GetAll();
            var models = MapperService.Instance.Map<IEnumerable<CompositionModel>>(entities);

            var filteredModel = models.FirstOrDefault(selector);
            return filteredModel;
        }

        public CompositionModel GetCompositionById(int id)
        {
            var entity = uow.CompositionRepository.GetById(id);
            var model = MapperService.Instance.Map<Composition, CompositionModel>(entity);

            return model;
        }

        public IEnumerable<CompositionModel> GetCompositions()
        {
            var entities = uow.CompositionRepository.GetAll();
            var models = MapperService.Instance.Map<IEnumerable<CompositionModel>>(entities);

            return models;
        }

        public void RemoveCompositionById(int id)
        {
            var work = uow.CompositionRepository.GetById(id);
            uow.CompositionRepository.Remove(work);

            uow.Commit();
        }

        public void UpdateComposition(UpdateCompositionModel work)
        {
            var entity = MapperService.Instance.Map<UpdateCompositionModel, Composition>(work);
            uow.CompositionRepository.Update(entity);

            uow.Commit();
        }
    }
}
