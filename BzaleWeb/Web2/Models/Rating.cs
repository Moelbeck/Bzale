using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web2.Models
{
    /// <summary>
    /// Rating of a company, made by another user. probably missing something
    /// </summary>
    public class Rating
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public virtual Company Company { get; set; }
        public virtual Comment Comment { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime Created { get; set; }
    }
}
