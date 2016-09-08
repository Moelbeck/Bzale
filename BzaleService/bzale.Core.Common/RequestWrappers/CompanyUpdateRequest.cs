using bzale.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzale.Common
{
    public class CompanyUpdateRequest
    {
        public AccountDTO Account { get; set; }
        public CompanyDTO Company { get; set; }
    }
}
