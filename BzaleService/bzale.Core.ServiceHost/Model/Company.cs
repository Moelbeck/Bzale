using bzale.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bzale.Model
{
    /// <summary>
    /// This is the company.
    /// An account belongs to a company, which might have multiple accounts
    /// Sale listings belongs to the company, not the account.
    /// </summary>
    public class Company : BaseContactInfo
    {

        public string Name { get; set; }
        public string VAT { get; set; }
        public bool IsVerified { get; set; }

        public Image Image { get; set; }
    }
}
