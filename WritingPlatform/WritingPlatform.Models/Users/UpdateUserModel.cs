namespace WritingPlatform.Models.Users
{
    public class UpdateUserModel : NewUserModel
    {
        bool IsDeleted { get; set; }
    }
}
