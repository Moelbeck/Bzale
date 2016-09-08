using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biz2biz.Model
{
    /// <summary>
    /// Product categories
    /// Can be 'Cars', 'Bricks', or other types. 
    /// Can be known by multiple job categories
    /// </summary>
    public class ProductCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Image Image { get; set; }
        public virtual List<JobCategory> JobCategories { get; set; } 
    }
}
