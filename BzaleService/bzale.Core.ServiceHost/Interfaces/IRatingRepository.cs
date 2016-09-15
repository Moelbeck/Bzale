using bzale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzale.WebService
{
    public interface IRatingRepository
    {
        void AddRating(Rating rating);
        Rating UpdateRating(Rating rating);
        void RemoveRating(int ratingid);
        void RemoveRating(Rating rating);
        Rating GetRating(int ratingid);
        List<Rating> GetRatingsForCompany(Company company, int page, int size);
        List<Rating> GetRatingsForCompany(int companyid, int page, int size);
    }
}
