﻿using bzale.Model;
using bzale.Repository.Abstract;
using bzale.Repository.DatabaseContext;
using System.Collections.Generic;
using System.Linq;

namespace bzale.Repository
{
   public class RatingRepository : GenericRepository< Rating>
    {
        public RatingRepository(BzaleDatabaseContext context) : base(context)
        {

        }
        public void AddRating(Rating rating)
        {
            Add(rating);
            Save();
        }
        public Rating UpdateRating(Rating rating)
        {
            Edit(rating);
            Save();
            return GetSingle(e => e.ID == rating.ID);
        }
        public void RemoveRating(int ratingid)
        {
            var rating = GetSingle(e => e.ID == ratingid);
            if (rating != null)
            {
                Delete(rating);
                Save();
            }
        }
        public void RemoveRating(Rating rating)
        {
            Delete(rating);
            Save();
        }
        public Rating GetRating(int ratingid)
        {
            return GetSingle(e => e.ID == ratingid);
        }
        public List<Rating> GetRatingsForCompany(Company company,int page, int size)
        {
            return Get(e => e.Company.ID == company.ID && e.Deleted ==null,page,size).ToList();
        }
        public List<Rating> GetRatingsForCompany(int companyid, int page, int size)
        {
            return Get(e => e.Company.ID == companyid && e.Deleted == null, page, size).ToList();
        }
    }
}
