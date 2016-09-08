using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web2.ViewModel
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int ManufacturerID { get; set; }
        public int ProductCategoryID { get; set; }
    }
}
