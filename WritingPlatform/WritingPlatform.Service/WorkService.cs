using System;
using System.Collections.Generic;
using System.Linq;
using WritingPlatform.Data.Abstractions;
using WritingPlatform.Data.Entities;
using WritingPlatform.Models.Works;
using WritingPlatform.Service.Absractions;
using WritingPlatform.Service.Mapping;

namespace WritingPlatform.Service
{
    public class WorkService : IWorkService
    {
        private readonly IDataUnitOfWork uow;

        public WorkService(IDataUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void AddWork(NewWorkModel work)
        {
            var entity = MapperService.Instance.Map<NewWorkModel, Work>(work);
            uow.WorkRepository.Create(entity);

            uow.Commit();
        }

        public WorkModel GetBy(Func<WorkModel, bool> selector)
        {
            var entities = uow.WorkRepository.GetAll();
            var models = MapperService.Instance.Map<IEnumerable<WorkModel>>(entities);

            var filteredModel = models.First(selector);
            return filteredModel;
        }

        public WorkModel GetById(int id)
        {
            var entity = uow.WorkRepository.GetById(id);
            var model = MapperService.Instance.Map<Work, WorkModel>(entity);

            return model;
        }

        public IEnumerable<WorkModel> GetWorks()
        {
            var entities = uow.WorkRepository.GetAll();
            var models = MapperService.Instance.Map<IEnumerable<WorkModel>>(entities);

            return models;
        }

        public void RemoveUserById(int id)
        {
            var work = uow.WorkRepository.GetById(id);
            uow.WorkRepository.Remove(work);

            uow.Commit();
        }

        public void UpdateWork(UpdateWorkModel work)
        {
            var entity = MapperService.Instance.Map<UpdateWorkModel, Work>(work);
            uow.WorkRepository.Update(entity);

            uow.Commit();
        }
    }
}
