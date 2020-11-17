using System;

namespace WritingPlatform.Models.Works
{
    public class NewWorkModel
    {
        public string Name { get; set; }

        public string Genre { get; set; }

        public DateTime PublicationTime { get; set; }

        public byte Rating { get; set; }

        public int UserId { get; set; }

        public string TextOfWork { get; set; }
    }
}
