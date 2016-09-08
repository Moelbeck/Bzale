using bzale.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace bzale.Model
{
    /// <summary>
    /// This is a user's category preferences (Recommendation system needs to be implemented)
    /// </summary>
    public class CategoryPreferences : Entity
    {
        public virtual Account Account { get; set; }

        public virtual List<Category> PreferedCategories { get; set; }       
    }
}
