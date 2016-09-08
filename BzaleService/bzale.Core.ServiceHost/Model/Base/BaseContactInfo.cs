using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bzale.Model.Base
{
    public abstract class BaseContactInfo: Entity
    {
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
