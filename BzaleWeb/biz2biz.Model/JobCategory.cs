using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace biz2biz.Model
{
    /// <summary>
    /// The job categories.
    /// Product categories can belong to multiple job categories
    /// </summary>
   public class JobCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public virtual Image Image { get; set; }


        

    }
}
