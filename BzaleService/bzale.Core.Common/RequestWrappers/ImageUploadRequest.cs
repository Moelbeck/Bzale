using bzale.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzale.Common
{
    public class ImageUploadRequest
    {
        public SaleListingDTO SaleListing { get; set; }

        public ImageUploadDTO Image { get; set; }
    }
}
