﻿namespace depross.Model.Base
{
    public abstract class BaseContactInfo: Entity
    {
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}