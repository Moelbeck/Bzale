using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace depross.ViewModel
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
