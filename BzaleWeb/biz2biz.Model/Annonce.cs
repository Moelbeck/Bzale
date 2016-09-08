using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using biz2biz.Enums;

namespace biz2biz.Model
{
    /// <summary>
    /// An Annonce is what the company is creating an annonce for.
    /// Could probably be renamed to Annonce - talk to Piotr about that.
    /// </summary>
    public class Annonce
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public  virtual Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// Max of 5 images
        /// </summary>
        public virtual List<Image> Images { get; set; } 

        public virtual Company Owner { get; set; }

        public virtual Account CreatedBy { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }


        public virtual Product Product { get; set; }

        public List<Comment> Comments { get; set; }

        public double Price { get; set; }

        public bool IsPriceNegotiable { get; set; }

        public virtual  AnnonceSubscription Subscription { get; set; }
        public eAmountType AmountType { get; set; }
        public int Amount { get; set; }
        
        [Column(TypeName = "DateTime2")]
        public DateTime Created { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? Updated { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? Deleted { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime ExpirationDate { get; set; }

    }
}
