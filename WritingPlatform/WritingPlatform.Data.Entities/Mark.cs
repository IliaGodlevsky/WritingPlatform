using WritingPlatform.Base.Abstractions;

namespace WritingPlatform.Data.Entities
{
    public class Mark : BaseEntity
    {
        public int CompositionId { get; set; }

        public int Rating { get; set; }
    }
}
