using System.Collections.Generic;
using WritingPlatform.Models.Compositions;
using WritingPlatform.Models.Users;

namespace WritingPlatform.Models
{
    public class UserWithCompositionsModel : UserModel
    {
        public IEnumerable<CompositionWithCommentsModel> Compositions { get; set; }
    }
}