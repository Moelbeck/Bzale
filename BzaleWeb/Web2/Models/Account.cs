using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web2.Enums;
using Web2.Models;

namespace Web2.Models
{
    /// <summary>
    /// This is the account of a user.
    /// </summary>
    public class Account : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public eGender? Gender { get; set; }
        public string Country { get; set; }
        public int? PostalCode { get; set; }
        public string Address { get; set; }

        public int? CompanyID { get; set; }

        [ForeignKey("CompanyID")]
        public virtual Company Company { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime Created { get; set; } = DateTime.Now;
        [Column(TypeName = "DateTime2")]
        public DateTime? Updated { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? Deleted { get; set; }


    }
}
