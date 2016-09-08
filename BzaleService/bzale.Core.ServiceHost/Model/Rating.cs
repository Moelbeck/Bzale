﻿using bzale.Common;
using bzale.Model.Base;

namespace bzale.Model
{
    /// <summary>
    /// Rating of a company, made by another user. probably missing some fields
    /// </summary>
    public class Rating : Entity
    {
        public virtual Account Account { get; set; }
        public virtual Company Company { get; set; }
        public string Description{ get; set; }

        public eRating GivenRating { get; set; }

        public int Votes { get; set; }
    }
}