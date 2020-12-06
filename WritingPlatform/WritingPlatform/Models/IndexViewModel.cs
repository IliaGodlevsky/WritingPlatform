using System.Collections.Generic;

namespace WritingPlatform.Models
{
    public class IndexViewModel<TModel>
    {
        public IEnumerable<TModel> Collection { get; set; }

        public PageInfo PageInfo { get; set; }
    }   
}