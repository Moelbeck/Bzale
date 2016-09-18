

using System.ComponentModel.DataAnnotations;

namespace depross.ViewModel
{
    public class ProductDTO
    {
 
        public int ID { get; set; }
 
        [Display(Name="Navn")]
        public string Name { get; set; }

        public int ManufacturerID { get; set; }
 
        public int ProductCategoryID { get; set; }
    }
}
