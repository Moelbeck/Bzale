using AutoMapper;
using bzale.Common;
using bzale.Model;
using bzale.Repository;
using bzale.Repository.DatabaseContext;
using bzale.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bzale.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RatingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RatingService.svc or RatingService.svc.cs at the Solution Explorer and start debugging.
    public class RatingWebService : IRatingWebService
    {

        private readonly RatingRepository _ratingRepository;

        public RatingWebService(BzaleDatabaseContext context)
        {
            _ratingRepository = new RatingRepository(context);
        }
        public bool CreateRating(RatingDTO viewmodel)
        {
            try
            {
                Rating newrating = Mapper.Map<RatingDTO, Rating>(viewmodel);
                _ratingRepository.AddRating(newrating);
                return true;

            }
            catch (Exception ex)
            {

                throw;
                return false;
            }
        }

        public RatingDTO GetMostPositiveRatingForCompany(int companyID)
        {
            try
            {
                var allratings = _ratingRepository.GetRatingsForCompany(companyID, 1, int.MaxValue);
                var mostpositive = allratings.Aggregate((i1, i2) => i1.Votes >= i2.Votes ? i1 : i2);
                RatingDTO viewmodel = Mapper.Map<Rating, RatingDTO>(mostpositive);
                return viewmodel;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<RatingDTO> GetRatingsForCompany(int companyID, int page, int size)
        {
            try
            {
                var allratings = _ratingRepository.GetRatingsForCompany(companyID, page, size);
                return allratings.Select(e => Mapper.Map<Rating, RatingDTO>(e)).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool RemoveRating(int id)
        {
            try
            {
                _ratingRepository.RemoveRating(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateRating(RatingDTO viewmodel)
        {
            try
            {
                Rating updatedrating = Mapper.Map<RatingDTO, Rating>(viewmodel);
                _ratingRepository.UpdateRating(updatedrating);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
