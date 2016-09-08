using bzale.Common;
using bzale.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bzale.Model.Log
{
    public class LogUserSaleListing : BaseLog
    {
        public int SaleListingID { get; set; }

        public eLogSaleListingType LogType{get;set;}
    }
}
