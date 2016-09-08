using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using biz2biz.Enums;

namespace biz2biz.Model
{
    /// <summary>
    /// This is the account of a user.
    /// </summary>
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public eGender Gender { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string PswSalt { get; set; }
        public string CryptedPassword { get; set; }

        public int CompanyID { get; set; }

        public bool HaveValidatedMail { get; set; }

        [ForeignKey("CompanyID")]
        public virtual Company Company { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime Created { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? Updated { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? Deleted { get; set; }


    }
}
