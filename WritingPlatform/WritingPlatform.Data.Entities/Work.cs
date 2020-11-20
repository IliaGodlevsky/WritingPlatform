using System;
using WritingPlatform.Base.Abstractions;

namespace WritingPlatform.Data.Entities
{
    public class Work : BaseEntity
    {
        public string Name { get; set; }

        public string Genre { get; set; }

        public DateTime PublicationTime { get; set; }

        public double Rating { get; set; }

        public int UserId { get; set; }

        public string TextOfWork { get; set; }

        public virtual IEquatable<Comment> Comments { get; set; }
    }
}
