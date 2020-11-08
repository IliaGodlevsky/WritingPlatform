using System;
using System.Collections.Generic;
using WritingPlatform.Base.Abstractions;

namespace WritingPlatform.Data.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public DateTime BirthDay { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public IEnumerable<Work> Works { get; set; }

    }
}
