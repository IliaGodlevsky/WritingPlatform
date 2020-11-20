using System;

namespace WritingPlatform.Models.Works
{
    public class WorkFilteringModel
    {
        public string Name { get; set; }

        public string Genre { get; set; }

        public DateTime? PublicationTimeFrom { get; set; }

        public DateTime? PublicationTimeTo { get; set; }

        public double? Rating { get; set; }
    }
}
