using System.Collections.Generic;
using WritingPlatform.Models.Comments;
using WritingPlatform.Models.Users;

namespace WritingPlatform.Models
{
    public class BestWorkModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public byte Rating { get; set; }

        public int UserId { get; set; }

        public string TextOfWork { get; set; }

        public UserModel Author { get; set; }

        public IEnumerable<CommentModel> Comments { get; set; }
    }
}