using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Web2.Enums;

namespace Web2.ViewModel.AnnonceViewModels
{
  public  class AnnonceCreateViewModel
    {
        [Display(Name = "Overskrift")]
        public string Title { get; set; }
        [Display(Name = "Beskrivelse")]

        public string Description { get; set; }
        [Display(Name = "Fabrikant")]
        public string ManufacturerName { get; set; }
        public int ManufacturerID { get; set; }
        [Display(Name = "Upload billeder")]
        public virtual List<string> ImageURLs { get; set; }
        [Display(Name = "Produkt type")]
        public string ProductName { get; set; }
        public int ProductID { get; set; }
        [Display(Name = "Produkt kategori")]
        public int ProductCategoryID { get; set; }

        [Display(Name = "Job specificerede kategorier")]
        public List<int> JobSpecificCategorieIDs { get; set; }
        [Display(Name = "Pris")]
        public double? Price { get; set; }
        [Display(Name = "Kan prisen forhandles?")]
        public bool IsPriceNegotiable { get; set; }
        [Display(Name = "Mængde type")]
        public eAmountType AmountType { get; set; }
        [Display(Name = "Overskrift")]
        public int Amount { get; set; }
    }
}
