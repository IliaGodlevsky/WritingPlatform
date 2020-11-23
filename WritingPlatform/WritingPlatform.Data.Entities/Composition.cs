using System;
using WritingPlatform.Base.Abstractions;

namespace WritingPlatform.Data.Entities
{
    public class Composition : BaseEntity
    {
        public string Name { get; set; }

        public string Genre { get; set; }

        public DateTime PublicationTime { get; set; }

        public double Rating { get; set; }

        public int NumberOfMarks { get; set; }

        public int UserId { get; set; }

        public string Content { get; set; }
    }
}
