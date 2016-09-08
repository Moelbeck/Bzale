using System.Collections.Generic;
using biz2biz.Enums;

namespace biz2biz.ViewModel.AnnonceViewModels
{
   public class AnnonceUpdateViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int ManufacturerID { get; set; }

        public virtual List<string> ImageURLs { get; set; }

        public int ProductID { get; set; }

        public int ProductCategoryID { get; set; }

        public List<int> JobSpecificCategorieIDs { get; set; }

        public double Price { get; set; }

        public bool IsPriceNegotiable { get; set; }

        public eAmountType AmountType { get; set; }
        public int Amount { get; set; }
    }
}
