using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace biz2biz.Model
{
    /// <summary>
    /// Comments can belong to both a rating and a annonce 
    /// </summary>
    public class Comment
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        public bool IsPrivateMessage { get; set; }

        public virtual Account Sender { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime Created { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime Deleted { get; set; }
    }
}
