using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web2.Models
{
    /// <summary>
    /// This is the company.
    /// An account belongs to a company, which might have multiple accounts
    /// Annonce's belongs to the company, not the account.
    /// </summary>
    public class Company
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime Created { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? Updated { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? Deleted { get; set; }
        public string VAT { get; set; }
        public bool IsVerified { get; set; }

        public string Country { get; set; }
        public int PostalCode { get; set; }
        public string Addresse { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Image Image { get; set; }
    }
}
