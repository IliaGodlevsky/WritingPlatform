using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingPlatform.Models.Users;

namespace WritingPlatform.Models.Compositions
{
    public class AuthoreCompositionModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public UserModel Author { get; set; }

        public string Content { get; set; }

        public DateTime PublicationTime { get; set; }     

        public double Rating { get; set; }

        public int NumberOfMarks { get; set; }
    }
}
