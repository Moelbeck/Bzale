using bzale.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bzale.ViewModel
{
    public class ManufacturerDTO
    {

        [Display(Name="Navn")]
        public string Name { get; set; }

        [Display(Name="Beskrivelse")]
        public string Description { get; set; }

        //List of categories this manufacturer belongs to
        public virtual List<int> CategoryIDs { get; set; }
    }
}
