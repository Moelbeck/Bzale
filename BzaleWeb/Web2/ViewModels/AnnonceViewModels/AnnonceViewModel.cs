using System;
using System.Collections.Generic;
using Web2.Enums;

namespace Web2.ViewModel.AnnonceViewModels
{
   public class AnnonceViewModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public string ManufacturerName { get; set; }

        /// <summary>
        /// Max of 5 images
        /// </summary>
        public List<string> ImagesUrls { get; set; }

        public string OwnerName { get; set; }
        public int OwnerID { get; set; }
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }
        public DateTime ExpirationDate { get; set; }


        public string ProductName { get; set; }

        public eAmountType AmountType { get; set; }
        public int Amount { get; set; }

        public double Price { get; set; }

        public bool IsPriceNegotiable { get; set; }

    }
}
