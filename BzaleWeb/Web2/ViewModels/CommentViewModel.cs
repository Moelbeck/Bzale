using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web2.ViewModel
{
   public class CommentViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        public bool IsPrivateMessage { get; set; }

        public int SenderID { get; set; }
        public string SenderName { get; set; }
    }
}
