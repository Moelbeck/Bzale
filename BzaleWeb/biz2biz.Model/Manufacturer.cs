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
    /// Manufactures of product types.
    /// </summary>
   public class Manufacturer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime Created { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? Updated { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? Deleted { get; set; }
        public int CategoryID { get; set; }

    }
}
