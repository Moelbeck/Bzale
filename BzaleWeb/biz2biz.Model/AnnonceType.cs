using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biz2biz.Model
{
    /// <summary>
    /// THIS IS NOT MAPPED WITH EF; ONLY TO SHOW SEARCH RESULT, AND GET CORRECT PRODUCTTYPE IN RETURN
    /// </summary>
    public class AnnonceType
    {
        public string ProductName { get; set; }
        public int ProductID { get; set; }
        public string ManufacturerName { get; set; }
        public int ManufacturerID { get; set; }
        public int ProductCategoryID { get; set; }

        public string ImageURL { get; set; }
        public string Grouping { get; set; }
    }
}
