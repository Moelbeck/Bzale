using bzale.Common;
using System.Collections.Generic;

namespace bzale.ViewModel
{

    public class SaleListingUpdateDTO
    {
         
        public int ID { get; set; }
         
        public string Title { get; set; }
         
        public string Description { get; set; }
         
        public int ManufacturerID { get; set; }
         
        public virtual List<ImageDTO> Images { get; set; }
         
        public int ProductID { get; set; }
         
        public int ProductCategoryID { get; set; }
         
        //public virtual List<eJobType> JobTypes { get; set; }
         
        public double Price { get; set; }
                  
        public string AmountType { get; set; }
         
        public int Amount { get; set; }
    }
}
