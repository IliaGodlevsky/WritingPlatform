using System;
using System.Collections.Generic;
using WritingPlatform.Models.Comments;

namespace WritingPlatform.Models
{
    public class WorkWithCommentsModel
    {
        public string Name { get; set; }

        public string Genre { get; set; }

        public DateTime PublicationTime { get; set; }

        public double Rating { get; set; }

        public int UserId { get; set; }

        public string TextOfWork { get; set; }

        public IEnumerable<CommentModel> Comments { get; set; }
    }
}