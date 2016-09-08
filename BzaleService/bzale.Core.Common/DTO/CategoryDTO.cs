using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bzale.ViewModel
{
    public class CategoryDTO
    {
        public int ID { get; set; }
        [Display(Name = "Navn")]

        public string Name { get; set; }

        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }

        public ImageDTO Image { get; set; }
    }
}
