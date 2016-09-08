using bzale.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bzale.ViewModel
{
    public class ImageUploadDTO
    {
        public string FileName { get; set; }

        public eJobType JobType { get; set; }
        public eImageType ImageType { get; set; }
        public byte[] Content { get; set; }
        
    }
}
