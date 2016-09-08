using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web2.Enums;

namespace Web2.Models
{
    /// <summary>
    /// This is the Subscription descriptions for a item subscription.
    /// May vary, and may be unnecessary.
    /// </summary>
   public class AnnonceSubscriptionDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public eItemSubscription ItemSubscriptionType { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public virtual List<Image> Images { get; set; } 
    }
}
