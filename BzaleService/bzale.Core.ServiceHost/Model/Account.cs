﻿using bzale.Model.Base;
using bzale.Common;
using System.Collections.Generic;

namespace bzale.Model
{
    /// <summary>
    /// This is the account of a user.
    /// </summary> 
    public class Account : BaseContactInfo    {


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public eGender Gender { get; set; }

        public eAccountType Type { get; set; }

        public bool HasValidatedMail { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public virtual Company Company { get; set; }

        public virtual List<SaleListing> Following { get; set; }

    }
}
