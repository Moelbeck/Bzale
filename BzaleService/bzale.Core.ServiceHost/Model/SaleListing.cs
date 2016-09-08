using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using bzale.Model.Base;
using bzale.Common;

namespace bzale.Model
{

    public class SaleListing : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual List<Image> Images { get; set; } 

        public virtual Company Owner { get; set; }

        public virtual Account CreatedBy { get; set; }

        public virtual Category Category { get; set; }

        public virtual ProductType Product { get; set; }

        public virtual List<Comment> Comments { get; set; }
        public double Price { get; set; }
        public virtual Subscription Subscription { get; set; }
        public eAmountType AmountType { get; set; }
        public int Amount { get; set; }
        
        public DateTime ExpirationDate { get; set; }

    }
}
