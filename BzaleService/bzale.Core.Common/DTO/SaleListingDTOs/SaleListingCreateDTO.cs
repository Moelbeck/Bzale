using bzale.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bzale.ViewModel
{

    public class SaleListingCreateDTO
    {         
        [Display(Name="Titel")]
        public string Title { get; set; }
         [Display(Name ="Beskrivelse")]
        public string Description { get; set; }

         
        public string ManufacturerName { get; set; }
         
        public int ManufacturerID { get; set; }
         
        public List<ImageDTO> Images { get; set; }
         
        public string ProductName { get; set; }
         
        public int ProductID { get; set; }
         
        public int ProductCategoryID { get; set; }
         
        //public virtual List<eJobType> JobTypes { get; set; }
         
        public double Price { get; set; }
         
        public eAmountType AmountType { get; set; }
         
        public int Amount { get; set; }

         
        public int CreatedById { get; set; }
    }
}
