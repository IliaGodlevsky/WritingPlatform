using System;
using System.Collections.Generic;
using WritingPlatform.Models.Comments;
using WritingPlatform.Models.Users;

namespace WritingPlatform.Models.Compositions
{
    public class DetailedCompositionModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public string Content { get; set; }

        public DateTime PublicationTime { get; set; }

        public IEnumerable<CommentModel> Comments { get; set; }

        public double Mark { get; set; }

        public UserModel Author { get; set; }
    }
}
