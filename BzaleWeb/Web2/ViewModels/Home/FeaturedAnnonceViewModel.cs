using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2.Models;

namespace Web2.ViewModels.Home
{
    public class FeaturedAnnonceViewModel
    {
        public IEnumerable<Annonce> Announces { get; set; } = new List<Annonce>();
    }
}
