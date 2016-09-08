using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using biz2biz.Enums;

namespace biz2biz.Model
{
    /// <summary>
    /// Images is for categories, companies, annonce's, advertisers and advertisements
    /// </summary>
   public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string ImageURL { get; set; }

        public eImageType Type { get; set; }
       
       [Column(TypeName = "DateTime2")]
        public DateTime Created { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? Deleted { get; set; }
    }
}
