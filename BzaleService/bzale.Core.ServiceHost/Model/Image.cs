using bzale.Model.Base;
using bzale.Common;

namespace bzale.Model
{
    /// <summary>
    /// Images is for categories, companies, sale listing's, advertisers and advertisements
    /// </summary>
    public class Image : Entity
    {

        public string ImageURL { get; set; }

        public eImageType Type { get; set; }
       
    }
}
