using bzale.Common;
using bzale.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bzale.Model
{
    public class Subscription : Entity
    {
        public double Price { get; set; }

        public eSubscription SubscriptionCategory { get; set; }

        public eSubscriptionType SubscriptionType { get; set; }


        [Column(TypeName = "DateTime2")]
        public DateTime ExpirationDate
        {
            get; set;
        }
    }
}
