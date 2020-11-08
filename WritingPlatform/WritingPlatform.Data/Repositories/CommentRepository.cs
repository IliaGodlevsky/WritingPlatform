using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingPlatform.Data.Abstractions.Repositories;
using WritingPlatform.Data.Entities;

namespace WritingPlatform.Data.Repositories
{
    internal class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context)
        {
        }
    }
}
