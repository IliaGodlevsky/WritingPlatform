using WritingPlatform.Base.Abstractions;

namespace WritingPlatform.Data.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public int WorkId { get; set; }
    }
}
