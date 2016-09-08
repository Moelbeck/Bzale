using bzale.Common;
using bzale.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bzale.Model.Log
{
    public class LogUserLogin : BaseLog
    {

        public eLoginType Type { get; set; }

    }
}
