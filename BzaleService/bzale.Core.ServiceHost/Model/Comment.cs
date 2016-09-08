using bzale.Common;
using bzale.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bzale.Model
{
    public class Comment : BaseComment
    {

        public bool IsPrivateMessage { get; set; }

        public eCommentType CommentType { get; set; }

        public virtual List<CommentAnswer> Answers { get; set; }
    }
}
