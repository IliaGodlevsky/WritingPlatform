using WritingPlatform.Base.Abstractions;

namespace WritingPlatform.Data.Entities
{
    public class User : BaseEntity
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public bool IsDeleted { get; set; }
    }
}
