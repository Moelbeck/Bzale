using bzale.Common;
using System;
using System.Collections.Generic;

namespace bzale.ViewModel
{
    public class SaleListingDTO
    {
        
        public int ID { get; set; }

        
        public string Title { get; set; }

        
        public string Description { get; set; }
        
        public string ManufacturerName { get; set; }

        /// <summary>
        /// Max of 5 images
        /// </summary>
        
        public List<ImageDTO> Images { get; set; }

        
        public string CompanyName { get; set; }
        
        public int CompanyID { get; set; }
        
        public int CreatedByID { get; set; }
        public string CreatedByFirstName { get; set; }
        public string CreatedByLastname { get; set; }

        
        public DateTime Created { get; set; }
        
        public DateTime ExpirationDate { get; set; }

        public int ProductID { get; set; }
        
        public string ProductName { get; set; }
        
        public string AmountType { get; set; }
        
        public int Amount { get; set; }
        
        public double Price { get; set; }
        
        public bool IsPriceNegotiable { get; set; }
        
        public eJobType JobType { get; set; }

    }
}
