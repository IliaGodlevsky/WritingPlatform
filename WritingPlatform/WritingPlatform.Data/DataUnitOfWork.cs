using WritingPlatform.Data.Abstractions;
using WritingPlatform.Data.Abstractions.Repositories;
using WritingPlatform.Data.Repositories;

namespace WritingPlatform.Data
{
    public class DataUnitOfWork : IDataUnitOfWork
    {
        private readonly DataDbContext context;

        private IUserRepository userRepository;

        private ICommentRepository commentRepository;

        private ICompositionRepository compositionRepository;

        public DataUnitOfWork(string connectionString)
        {
            context = new DataDbContext(connectionString);
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(context);
                }

                return userRepository;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                if (commentRepository == null)
                {
                    commentRepository = new CommentRepository(context);
                }

                return commentRepository;
            }
        }

        public ICompositionRepository CompositionRepository
        {
            get
            {
                if (compositionRepository == null)
                {
                    compositionRepository = new CompositionRepository(context);
                }

                return compositionRepository;
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
