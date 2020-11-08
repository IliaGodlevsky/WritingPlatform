using System;

namespace WritingPlatform.Base.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
