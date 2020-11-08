using System.Collections.Generic;
using WritingPlatform.Data.Abstractions;
using WritingPlatform.Data.Entities;
using WritingPlatform.Service.Absractions;

namespace WritingPlatform.Service
{
    public class WorkService : IWorkService
    {
        private readonly IDataUnitOfWork uow;

        public WorkService(IDataUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void AddWork(Work work)
        {
            uow.WorkRepository.Create(work);
            uow.Commit();
        }

        public Work GetById(int id)
        {
            return uow.WorkRepository.GetById(id);
        }

        public IEnumerable<Work> GetWorks()
        {
            return uow.WorkRepository.GetAll();
        }

        public void RemoveUserById(int id)
        {
            var work = uow.WorkRepository.GetById(id);
            uow.WorkRepository.Remove(work);
            uow.Commit();
        }

        public void UpdateWork(Work work)
        {
            uow.WorkRepository.Update(work);
            uow.Commit();
        }
    }
}
