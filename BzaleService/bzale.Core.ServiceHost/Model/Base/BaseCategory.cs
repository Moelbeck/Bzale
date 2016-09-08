using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzale.Model.Base
{
    public class BaseCategory:Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual Image Image { get; set; }
    }
}
