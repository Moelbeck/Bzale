using depross.Model.Base;
using System.Collections.Generic;

namespace depross.Model
{
    /// <summary>
    /// The job categories.
    /// Product categories can belong to multiple job categories
    /// </summary>
    public class Category : BaseCategory
    {
        
        public virtual List<SubCategory> SubCategories { get; set; }

    }

    public class SubCategory : BaseCategory
    {
        public virtual Category MainCategory { get; set; }
    }
}
