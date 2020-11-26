using System;

namespace WritingPlatform.Models.Compositions
{
    public class NewCompositionModel
    {
        public string Name { get; set; }

        public string Genre { get; set; }

        public int UserId { get; set; }

        public string Content { get; set; }

        public DateTime PublicationTime { get; set; }
    }
}
