using System;
using System.Collections.Generic;

namespace WritingPlatform.Models
{
    public class UserWithWorksModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDay { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public bool IsDeleted { get; set; }

        public IEnumerable<WorkWithCommentsModel> Works { get; set; }
    }
}