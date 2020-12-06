using WritingPlatform.Base.Abstractions;
using WritingPlatform.Data.Abstractions.Repositories;

namespace WritingPlatform.Data.Abstractions
{
    public interface IDataUnitOfWork : IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        ICommentRepository CommentRepository { get; }

        ICompositionRepository CompositionRepository { get; }

        IMarkRepository MarkRepository { get; }
    }
}
