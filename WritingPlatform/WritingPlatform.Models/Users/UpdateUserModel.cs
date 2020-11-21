namespace WritingPlatform.Models.Users
{
    public class UpdateUserModel : NewUserModel
    {
        public bool IsDeleted { get; set; }
    }
}
