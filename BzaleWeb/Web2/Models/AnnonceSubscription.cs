using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web2.Enums;

namespace Web2.Models
{
    /// <summary>
    /// You can subscribe for an item.
    /// Check eItemSubscription to see the types.
    /// </summary>
    public class AnnonceSubscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public eItemSubscription ItemSubscriptionType { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime Created { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime Deleted { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime ExpirationDate { get; set; }
    }
}
