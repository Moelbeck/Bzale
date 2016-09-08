using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web2.Models;

namespace Web2.Models
{
    /// <summary>
    /// This is for advertisers advertisements, when we come to that part.
    /// </summary>
    public class Advertisement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public virtual Image Image { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime Created { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime ExpirationDate { get; set; }

        public virtual Advertiser Advertiser { get; set; }
    }
}
