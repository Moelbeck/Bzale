using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web2.Models
{
    /// <summary>
    /// This is advertisers, which can have multiple advertisements
    /// </summary>
   public class Advertiser
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
        public string Email { get; set; }
       public string Phone { get; set; }
       public string URL { get; set; }

       public List<Advertisement> Advertisements { get; set; } 
    }
}
