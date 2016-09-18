﻿using depross.Model.Base;

namespace depross.Model
{
    /// <summary>
    /// This is product types a manufacturer have.
    /// A product type refers to a product category.
    /// This might vary from product type, as a manufacturer can deliver different product types.
    /// </summary>
    public class ProductType : Entity
    {
        public string Name { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Category Category { get; set; }

    }
}