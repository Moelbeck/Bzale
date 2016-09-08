using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web2.Models
{
    /// <summary>
    /// This is product types a manufacturer might have.
    /// A product type refers to a product category.
    /// This might vary from product type, as a manufacturer can deliver different product types.
    /// </summary>
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime Created { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? Deleted { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }

    }
}
