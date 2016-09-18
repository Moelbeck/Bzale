using depross.Extension;
using depross.Model;
using depross.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace depross.service
{
    public class CreateAndUpdateService
    {
        private static int DAYSBEFOREEXPIRING = 28;

        public Company CreateCompanyObject(CompanyDTO newcompany)
        {
            Company copy = new Company
            {
                Name = newcompany.Name,
                PostalCode = newcompany.PostalCode,
                Address = newcompany.Address,
                Country = newcompany.Country,
                Email = newcompany.Email,
                Phone = newcompany.Phone,
                IsVerified = false,
                VAT = newcompany.VAT
            };
            return copy;
        }

        internal Company CreateCompanyObject(string vat, string companyName, string companyAddress)
        {
            Company copy = new Company
            {
                Name = companyName,
                Address = companyAddress,
                VAT = vat,
                IsVerified = false
            };
            return copy;
        }
        public SaleListing CreateSaleListingObject(SaleListingCreateDTO newsalelisting, Account owner, ProductType product,Category category)
        {
            SaleListing salelisting = new SaleListing
            {
                CreatedBy = owner,
                Owner = owner.Company,
                Product = product,
                Comments = new List<Comment>(),
                ExpirationDate = DateTime.Now.AddDays(DAYSBEFOREEXPIRING),
                Amount = newsalelisting.Amount,
                AmountType = newsalelisting.AmountType,
                Category = category,
                Description = newsalelisting.Description,
                Price = newsalelisting.Price,
                Title = newsalelisting.Title,
                
                Subscription = new Subscription(),
                
                
            };
            return salelisting;

        }
        public Company UpdateCompanyFields(Company current, Company updated)
        {
            Company copy = new Company
            {
                ID = current.ID,
                Name = updated.Name.Trim().Any() ? updated.Name : current.Name,
                PostalCode = updated.PostalCode,
                Address = updated.Address,
                Country = updated.Country,
                Email = updated.Email.IsValidEmail() ? updated.Email : current.Email,
                Phone = updated.Phone.IsValidPhoneNr() ? updated.Phone : current.Phone,
                IsVerified = current.IsVerified
            };
            return copy;
        }

        public Account UpdateAccountFields(Account current, Account updated)
        {
            Account copy = new Account
            {
                ID = current.ID,
                FirstName =updated.FirstName,
                LastName = updated.LastName,
                Address = updated.Address ,
                Email = updated.Email.IsValidEmail() ? updated.Email : current.Email,
                Phone = updated.Phone.IsValidPhoneNr() ? updated.Phone : current.Phone,
                Gender = updated.Gender,
                Password = current.Password,
                Salt = current.Salt,
                Company = current.Company,
                HasValidatedMail = current.HasValidatedMail,
                Country = updated.Country,
                PostalCode = updated.PostalCode
            };
            return copy;
        }

        /// <summary>
        /// Updates the fields for a SaleListing object, before it is calling the database.
        /// The reason is, that the viewmodel does not map reference property, like CreatedBy or Comments proberly.
        /// </summary>
        /// <returns></returns>
        public SaleListing UpdateSaleListingFields(SaleListing current, SaleListing updated)
        {
            SaleListing copy = new SaleListing
            {
                ID = current.ID,
                CreatedBy = current.CreatedBy,
                Comments = current.Comments,
                Amount = updated.Amount,
                AmountType = updated.AmountType,
                Images = current.Images, //Does not update images from this!
                Category = updated.Category,
                Description = updated.Description,
                ExpirationDate = current.ExpirationDate,
                Price = updated.Price,
                Title = updated.Title,
                Owner = current.Owner,
                Subscription = current.Subscription,
                Product = updated.Product
            };
            return copy;
        }
    }
}