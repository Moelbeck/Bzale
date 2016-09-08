using System;

namespace biz2biz.ViewModel.CorporationViewModels
{
    public class ManufacturerViewModel
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Update { get; set; }
        public DateTime Deleted { get; set; }
    }
}
