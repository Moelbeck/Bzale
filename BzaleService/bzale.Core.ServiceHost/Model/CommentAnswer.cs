using bzale.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bzale.Model
{
   public class CommentAnswer :BaseComment
    {
        public virtual Comment ParentComment { get; set; }
    }
}
