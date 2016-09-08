using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Web2.Models
{
    /// <summary>
    /// This is a user's category preferences (Recommendation system needs to be implemented)
    /// </summary>
    public class CategoryPreferences
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //public int AccountID { get; set; }

        //[ForeignKey("AccountID")]
        public virtual Account Account { get; set; }

        public virtual List<JobCategory> PreferedMainCategories { get; set; }

        
        [Column(TypeName = "DateTime2")]
        public DateTime Created { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? Updated { get; set; }
    }
}
