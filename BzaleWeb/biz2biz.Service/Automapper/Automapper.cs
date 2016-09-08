using System;
using System.Linq;
using AutoMapper;
using biz2biz.Enums;
using biz2biz.Model;
using biz2biz.ViewModel;
using biz2biz.ViewModel.AccountViewModels;
using biz2biz.ViewModel.AnnonceViewModels;
using biz2biz.ViewModel.CorporationViewModels;
using biz2biz.ViewModel.Account;

namespace biz2biz.Service.Automapper
{
    public static class Automapper
    {
        public static void Configure()
        {
            ConfigureUserMapping();
        }
        private static void ConfigureUserMapping()
        {
            #region Account Mapping
            Mapper.CreateMap<Account, AccountViewModel>()
                .ForMember(e => e.Gender, o => o.MapFrom(e => e.Gender.ToString()))
                .ForMember(e => e.Company, o => o.MapFrom(account => account.Company));
            Mapper.CreateMap<AccountViewModel, Account>()
                .ForMember(e => e.CryptedPassword, o => o.Ignore())
                .ForMember(e => e.PswSalt, o => o.Ignore())
                .ForMember(e => e.Created, o => o.Ignore())
                .ForMember(e => e.Updated, o => o.Ignore())
                .ForMember(e => e.Deleted, o => o.Ignore())
                                .ForMember(e => e.HaveValidatedMail, o => o.Ignore())

                .ForMember(e => e.CompanyID, o => o.Ignore())
                .ForMember(e => e.Company, o => o.MapFrom(account => account.Company));

            Mapper.CreateMap<AccountCreateViewModel, Account>()
                .ForMember(e => e.Company,
                    o =>
                        o.MapFrom(
                            x =>
                                new Company
                                {
                                    Name = x.CompanyName,
                                    VAT = x.VAT,
                                    Addresse = x.CompanyAddress,
                                    Created = DateTime.Now,
                                    Country = "Denmark"
                                }))
                .ForMember(e => e.Gender, o => o.Ignore())
                .ForMember(e => e.FirstName, o => o.MapFrom(x => x.Name.Split(' ')[0]))
                .ForMember(e => e.LastName, o => o.MapFrom(x => x.Name.Split(' ').Count() > 1 ? x.Name.Split(' ')[x.Name.Split(' ').Count() - 1] : ""))
                .ForMember(e => e.PswSalt, o => o.Ignore())
                .ForMember(e => e.CryptedPassword, o => o.Ignore())
                .ForMember(e => e.Updated, o => o.Ignore())
                .ForMember(e => e.Created, o => o.MapFrom(s => DateTime.Now))
                .ForMember(e => e.Deleted, o => o.Ignore())
                                .ForMember(e => e.HaveValidatedMail, o => o.Ignore())

                .ForMember(e => e.Country, o => o.Ignore())
                .ForMember(e => e.Phone, o => o.Ignore())
                .ForMember(e => e.PostalCode, o => o.Ignore())
                .ForMember(e => e.Address, o => o.Ignore())
                .ForMember(e => e.CompanyID, o => o.Ignore());

            Mapper.CreateMap<Account, AccountCreateViewModel>()
                .ForMember(e => e.Name, o => o.MapFrom(x => x.FirstName + " " + x.LastName))
                .ForMember(e => e.CompanyName, o => o.MapFrom(x => x.Company.Name))
                .ForMember(e => e.CompanyAddress, o => o.MapFrom(x => x.Company.Addresse))
                .ForMember(e => e.ConfirmEmail, o => o.Ignore())
                .ForMember(e => e.IsValidVAT, o => o.Ignore())
                .ForMember(e => e.IsVatInDatabase, o => o.Ignore())
                .ForMember(e => e.Password, o => o.Ignore())
                .ForMember(e => e.ConfirmEmail, o => o.Ignore())
                .ForMember(e => e.VAT, o => o.Ignore());

            Mapper.CreateMap<Account, AccountUpdateViewModel>()
                .ForMember(e => e.ConfirmPassword, o => o.Ignore())
                .ForMember(e => e.Password, o => o.Ignore())
                .ForMember(e => e.CompanyName, o => o.MapFrom(s => s.Company.Name))
                .ForMember(e => e.CompanyAddress, o => o.MapFrom(s => s.Company.Addresse))
                .ForMember(e => e.CompanyEmail, o => o.MapFrom(s => s.Company.Email))
                .ForMember(e => e.CompanyPhone, o => o.MapFrom(s => s.Company.Phone))
                .ForMember(e => e.VAT, o => o.MapFrom(s => s.Company.VAT));
            Mapper.CreateMap<AccountUpdateViewModel, Account>()
                .ForMember(e => e.Deleted, o => o.Ignore())
                .ForMember(e => e.Created, o => o.Ignore())
                .ForMember(e => e.Updated, o => o.Ignore())
                .ForMember(e => e.HaveValidatedMail, o => o.Ignore())
                .ForMember(e => e.CompanyID, o => o.Ignore())
                .ForMember(e => e.Company, o => o.MapFrom(s => new Company
                {
                    VAT = s.VAT,
                    Addresse = s.CompanyAddress,
                    Name = s.CompanyName,
                    Email = s.CompanyEmail,
                    Phone = s.CompanyPhone
                }))
                .ForMember(e => e.CryptedPassword, o => o.Ignore())
                .ForMember(e => e.PswSalt, o => o.Ignore());


            #endregion


            #region Company Mapping

            Mapper.CreateMap<Company, CompanyViewModel>()
                .ForMember(e => e.ImageViewModel, o => o.MapFrom(s => new ImageViewModel
                {
                    ID = s.ID,
                    ImageURL = s.Image.ImageURL
                }));
            Mapper.CreateMap<CompanyViewModel, Company>()
                .ForMember(e => e.Image, o => o.MapFrom(
                    s =>
                    new Image
                    {
                        ID = s.ImageViewModel.ID,
                        ImageURL = s.ImageViewModel.ImageURL,
                        Type = eImageType.Unknown
                    }))
                        .ForMember(e => e.Created, o => o.Ignore())
                        .ForMember(e => e.Updated, o => o.Ignore())
                        .ForMember(e => e.Deleted, o => o.Ignore());

            #endregion

            #region Category Mapping
            Mapper.CreateMap<JobCategory, CategoryViewModel>()
                .ForMember(e => e.ImageURL, o => o.MapFrom(s => s.Image.ImageURL));
            Mapper.CreateMap<CategoryViewModel, JobCategory>()
                .ForMember(e => e.Image, o => o.Ignore());

            Mapper.CreateMap<ProductCategory, CategoryViewModel>()
                .ForMember(e => e.ImageURL, o => o.MapFrom(s => s.Image.ImageURL));
            Mapper.CreateMap<CategoryViewModel, ProductCategory>()
                .ForMember(e => e.Image, o => o.Ignore())
                .ForMember(e => e.JobCategories, e => e.Ignore());
            #endregion


            #region Image Mapping
            Mapper.CreateMap<Image, ImageViewModel>();
            Mapper.CreateMap<ImageViewModel, Image>()
                .ForMember(e => e.Created, o => o.Ignore())
                .ForMember(e => e.Deleted, o => o.Ignore())
                .ForMember(e => e.Type, o => o.Ignore());
            #endregion
            #region Annonce Mapping
            Mapper.CreateMap<Annonce, AnnonceCreateViewModel>()
                //.ForMember(e => e.ProductCategoryID, o => o.MapFrom(s => s.ProductCategory.ID))
                  .ForMember(e => e.ImageURLs, o => o.MapFrom(s => (s.Images.Select(b => b.ImageURL))))
                  .ForMember(e => e.ProductID, o => o.MapFrom(s => s.Product.ID))
                  .ForMember(e => e.ManufacturerID, o => o.MapFrom(s => s.Manufacturer.ID))
                  .ForMember(e=>e.JobSpecificCategorieIDs,o=>o.Ignore())
                  .ForMember(e=>e.ManufacturerName,o=>o.MapFrom(s=>s.Manufacturer.Name))
                  .ForMember(e=>e.ProductName,o=>o.MapFrom(s=>s.Product.Name));
            Mapper.CreateMap<AnnonceCreateViewModel, Annonce>()
                .ForMember(e => e.Created, o => o.Ignore())
                .ForMember(e => e.Deleted, o => o.Ignore())
                .ForMember(e => e.Comments, o => o.Ignore())
                .ForMember(e => e.Updated, o => o.Ignore())
                .ForMember(e => e.CreatedBy, o => o.Ignore())
                .ForMember(e => e.Images, o => o.Ignore())
                .ForMember(e => e.Product, o => o.Ignore())
                .ForMember(e => e.Owner, o => o.Ignore())
                .ForMember(e => e.Subscription, o => o.Ignore())
                .ForMember(e=>e.ProductCategory,o=>o.MapFrom(s=>new ProductCategory {ID = s.ProductCategoryID}))
                .ForMember(e => e.Manufacturer, o => o.Ignore())
                .ForMember(e=>e.ID,o=>o.Ignore())
                .ForMember(e=>e.ExpirationDate,o=>o.Ignore());

            Mapper.CreateMap<Annonce, AnnonceViewModel>()
                .ForMember(e => e.ManufacturerName, o => o.MapFrom(s => s.Manufacturer.Name))
                .ForMember(e => e.OwnerID, o => o.MapFrom(s => s.Owner.ID))
                .ForMember(e => e.OwnerName, o => o.MapFrom(s => s.Owner.Name))
                .ForMember(e => e.ProductName, o => o.MapFrom(s => s.Product.Name))
                .ForMember(e => e.CreatedBy, o => o.MapFrom(s => s.CreatedBy.FirstName + " " + s.CreatedBy.LastName))
                .ForMember(e => e.ImagesUrls, o => o.MapFrom(s => s.Images.SelectMany(b => b.ImageURL)))
                //.ForMember(e => e.ProductCategory, o => o.Ignore())
                ;

            Mapper.CreateMap<AnnonceViewModel, Annonce>()
                .ForMember(e => e.CreatedBy, o => o.Ignore())
                .ForMember(e => e.Owner, o => o.Ignore())
                .ForMember(e => e.Comments, o => o.Ignore())
                .ForMember(e => e.Deleted, o => o.Ignore())
                .ForMember(e => e.Updated, o => o.Ignore())
                .ForMember(e => e.Product, o => o.Ignore())
                .ForMember(e => e.Images, o => o.Ignore())
                .ForMember(e => e.IsPriceNegotiable, o => o.Ignore())
                .ForMember(e => e.Manufacturer, o => o.Ignore())
                .ForMember(e => e.Subscription, o => o.Ignore())
                .ForMember(e => e.Manufacturer, o => o.Ignore())
                .ForMember(e => e.ProductCategory, o => o.Ignore())
                ;

            #endregion

            #region Product

            Mapper.CreateMap<Product, ProductViewModel>()
                .ForMember(e => e.ProductCategoryID, o => o.MapFrom(s => s.ProductCategory.ID))
                .ForMember(e=>e.ManufacturerID,o=>o.MapFrom(s=>s.Manufacturer.ID));
            Mapper.CreateMap<ProductViewModel, Product>()
                .ForMember(e => e.Created, o => o.Ignore())
                .ForMember(e => e.Deleted, o => o.Ignore())
                .ForMember(e=>e.Manufacturer,o=>o.Ignore())
                .ForMember(e=>e.ProductCategory,o=>o.Ignore());
            #endregion

            #region AnnonceType

            Mapper.CreateMap<AnnonceType, AnnonceTypeViewModel>();
            Mapper.CreateMap<AnnonceTypeViewModel, AnnonceType>();
            #endregion

            Mapper.AssertConfigurationIsValid();

        }
    }
}
