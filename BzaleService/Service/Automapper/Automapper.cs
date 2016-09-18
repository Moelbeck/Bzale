using System;
using System.Linq;
using AutoMapper;
using depross.Model;
using depross.ViewModel;

namespace biz2biz.Service.Automapper
{
    public class BzaleAutoMapper : Profile
    {
        public BzaleAutoMapper()
        {
            ConfigureUserMapping();
        }
        private static void ConfigureUserMapping()
        {
            Mapper.Initialize(m =>
            {
                #region Account
                m.CreateMap<Account, AccountDTO>()

                .ForMember(e => e.ID, o => o.MapFrom(account => account.ID))
                .ForMember(e => e.FirstName, o => o.MapFrom(account => account.FirstName))
                .ForMember(e => e.LastName, o => o.MapFrom(account => account.LastName))
                .ForMember(e => e.Phone, o => o.MapFrom(account => account.Phone))
                .ForMember(e => e.PostalCode, o => o.MapFrom(account => account.PostalCode))
                .ForMember(e => e.Address, o => o.MapFrom(account => account.Address))
                .ForMember(e => e.Gender, o => o.MapFrom(e => e.Gender))
                .ForMember(e => e.Email, o => o.MapFrom(account => account.Email))
                .ForMember(e => e.Company, o => o.MapFrom(a => new CompanyDTO
                {
                    ID = a.Company.ID,
                    Name = a.Company.Name,
                    Email = a.Company.Email,
                    Country = a.Company.Country,
                    Phone = a.Company.Phone,
                    Address = a.Company.Address,
                    Image = new ImageDTO { ID = a.Company.ID, ImageURL = a.Company.Image.ImageURL }
                }))
                .ForAllOtherMembers(e => e.Ignore());

                m.CreateMap<AccountDTO, Account>().ForMember(e => e.Gender, o => o.MapFrom(e => e.Gender.ToString()))
                .ForMember(e => e.ID, o => o.MapFrom(account => account.ID))
                .ForMember(e => e.FirstName, o => o.MapFrom(account => account.FirstName))
                .ForMember(e => e.LastName, o => o.MapFrom(account => account.LastName))
                .ForMember(e => e.Phone, o => o.MapFrom(account => account.Phone))
                .ForMember(e => e.PostalCode, o => o.MapFrom(account => account.PostalCode))
                .ForMember(e => e.Address, o => o.MapFrom(account => account.Address))
                .ForMember(e => e.Email, o => o.MapFrom(account => account.Email))
                                .ForMember(e => e.Company, o => o.MapFrom(a => new CompanyDTO
                {
                    ID = a.Company.ID,
                    Name = a.Company.Name,
                    Email = a.Company.Email,
                    Country = a.Company.Country,
                    Phone = a.Company.Phone,
                    Address = a.Company.Address,
                    Image = new ImageDTO { ID = a.Company.ID, ImageURL = a.Company.Image.ImageURL }
                }))
                .ForAllOtherMembers(e => e.Ignore());

                m.CreateMap<AccountCreateDTO, Account>()
                .ForMember(e => e.Email, o => o.MapFrom(x => x.Email))
                
                .ForMember(e => e.FirstName, o => o.MapFrom(x => x.FirstName))
                .ForMember(e => e.LastName, o => o.MapFrom(x => x.LastName))
                .ForMember(e => e.Created, o => o.MapFrom(s => DateTime.Now))
                .ForMember(e => e.Company, o => o.MapFrom(x => new Company {VAT = x.VAT, Address = x.CompanyAddress, Name = x.CompanyName }))
                .ForMember(e => e.FirstName, o => o.MapFrom(x => x.FirstName))
                .ForMember(e => e.FirstName, o => o.MapFrom(x => x.FirstName))
                .ForMember(e => e.FirstName, o => o.MapFrom(x => x.FirstName))
                .ForMember(e => e.FirstName, o => o.MapFrom(x => x.FirstName))
                .ForAllOtherMembers(e => e.Ignore());

                m.CreateMap<Account, AccountCreateDTO>()
                .ForMember(e => e.Email, o => o.MapFrom(x => x.Email))

                .ForMember(e => e.FirstName, o => o.MapFrom(x => x.FirstName))
                .ForMember(e => e.LastName, o => o.MapFrom(x => x.LastName))
                .ForMember(e => e.CompanyName, o => o.MapFrom(x => x.Company.Name))
                .ForMember(e => e.CompanyAddress, o => o.MapFrom(x => x.Company.Address))
                .ForAllOtherMembers(e => e.Ignore());

                m.CreateMap<Account, AccountUpdateDTO>()
                .ForMember(e => e.ID, o => o.MapFrom(s => s.ID))
                .ForMember(e => e.Email, o => o.MapFrom(x => x.Email))
                .ForMember(e => e.FirstName, o => o.MapFrom(s => s.FirstName))
                .ForMember(e => e.LastName, o => o.MapFrom(s => s.LastName))
                .ForMember(e => e.PostalCode, o => o.MapFrom(s => s.PostalCode))
                .ForMember(e => e.Gender, o => o.MapFrom(s => s.Gender))
                .ForMember(e => e.Country, o => o.MapFrom(s => s.Country))
                .ForMember(e => e.Address, o => o.MapFrom(s => s.Address))

                .ForAllOtherMembers(e => e.Ignore());

                m.CreateMap<AccountUpdateDTO, Account>()
                .ForMember(e => e.ID, o => o.MapFrom(s => s.ID))
                .ForMember(e => e.Email, o => o.MapFrom(x => x.Email))
                .ForMember(e => e.FirstName, o => o.MapFrom(s => s.FirstName))
                .ForMember(e => e.LastName, o => o.MapFrom(s => s.LastName))
                .ForMember(e => e.PostalCode, o => o.MapFrom(s => s.PostalCode))
                .ForMember(e => e.Gender, o => o.MapFrom(s => s.Gender))
                .ForMember(e => e.Country, o => o.MapFrom(s => s.Country))
                .ForMember(e => e.Address, o => o.MapFrom(s => s.Address))
                .ForAllOtherMembers(e => e.Ignore());

                m.CreateMap<Company, CompanyDTO>()
                .ForMember(e => e.ID, o => o.MapFrom(s => s.ID))
                .ForMember(e => e.Image, o => o.MapFrom(s => new ImageDTO { ImageURL = s.Image.ImageURL, ID = s.Image.ID }))
                .ForMember(e => e.Name, o => o.MapFrom(s => s.Name))
                .ForMember(e => e.Phone, o => o.MapFrom(s => s.Phone))
                .ForMember(e => e.PostalCode, o => o.MapFrom(s => s.PostalCode))
                .ForMember(e => e.Email, o => o.MapFrom(s => s.Email))
                .ForAllOtherMembers(e => e.Ignore());

                m.CreateMap<CompanyDTO, Company>()
                .ForMember(e => e.ID, o => o.MapFrom(s => s.ID))
                .ForMember(e => e.Image, o => o.MapFrom(s => new Image { ImageURL = s.Image.ImageURL, ID = s.Image.ID }))
                .ForMember(e => e.Name, o => o.MapFrom(s => s.Name))
                .ForMember(e => e.Phone, o => o.MapFrom(s => s.Phone))
                .ForMember(e => e.PostalCode, o => o.MapFrom(s => s.PostalCode))
                .ForMember(e => e.Email, o => o.MapFrom(s => s.Email))
                .ForAllOtherMembers(e => e.Ignore());
                #endregion

                #region Comment
                m.CreateMap<Comment, CommentDTO>()
                .ForMember(e=>e.ID,o=>o.MapFrom(s=>s.ID))
                .ForMember(e=>e.Message,o=>o.MapFrom(s=>s.Message))
                .ForMember(e=>e.Title,o=>o.MapFrom(s=>s.Title))
                .ForMember(e=>e.SenderID,o=>o.MapFrom(s=>s.Sender.ID))
                .ForMember(e=>e.SenderFirstName,o=>o.MapFrom(s=>s.Sender.FirstName))
                .ForMember(e=>e.SenderLastName,o=>o.MapFrom(s=>s.Sender.LastName))
                .ForMember(e=>e.SenderEmail,o=>o.MapFrom(s=>s.Sender.Email))
                .ForMember(e => e.IsPrivateMessage, o => o.MapFrom(s => s.IsPrivateMessage))
                .ForAllOtherMembers(e => e.Ignore());


                m.CreateMap<CommentDTO, Comment>()
                .ForMember(e => e.ID, o => o.MapFrom(s => s.ID))
                .ForMember(e => e.Message, o => o.MapFrom(s => s.Message))
                .ForMember(e => e.Title, o => o.MapFrom(s => s.Title))
                .ForMember(e => e.Sender, o => o.MapFrom(s => new Account { ID = s.SenderID, FirstName = s.SenderFirstName, LastName=s.SenderLastName, Email=s.SenderEmail}))
                .ForMember(e => e.IsPrivateMessage, o => o.MapFrom(s => s.IsPrivateMessage))
                .ForAllOtherMembers(e => e.Ignore());

                m.CreateMap<CommentAnswer, CommentDTO>()
                .ForMember(e => e.ID, o => o.MapFrom(s => s.ID))
                .ForMember(e => e.Message, o => o.MapFrom(s => s.Message))
                .ForMember(e => e.Title, o => o.MapFrom(s => s.Title))
                .ForMember(e => e.SenderID, o => o.MapFrom(s => s.Sender.ID))
                .ForMember(e => e.SenderFirstName, o => o.MapFrom(s => s.Sender.FirstName))
                .ForMember(e => e.SenderLastName, o => o.MapFrom(s => s.Sender.LastName))
                .ForMember(e => e.SenderEmail, o => o.MapFrom(s => s.Sender.Email))
                .ForAllOtherMembers(e => e.Ignore());


                m.CreateMap<CommentDTO, CommentAnswer>()
                .ForMember(e => e.ID, o => o.MapFrom(s => s.ID))
                .ForMember(e => e.Message, o => o.MapFrom(s => s.Message))
                .ForMember(e => e.Title, o => o.MapFrom(s => s.Title))
                .ForMember(e => e.Sender, o => o.MapFrom(s => new Account { ID = s.SenderID, FirstName = s.SenderFirstName, LastName = s.SenderLastName, Email = s.SenderEmail }))
                .ForAllOtherMembers(e => e.Ignore());

                #endregion

                #region Category Mapping
                m.CreateMap<Category, CategoryDTO>()
                                .ForMember(e => e.ID, o => o.MapFrom(x => x.ID))

                    .ForMember(e => e.Name, o => o.MapFrom(x => x.Name))
                    .ForMember(e => e.Description, o => o.MapFrom(x => x.Description))
                    .ForMember(e => e.Image, o => o.MapFrom(s => new ImageDTO { ID = s.Image.ID, ImageURL = s.Image.ImageURL }))
                .ForAllOtherMembers(e => e.Ignore());

                m.CreateMap<CategoryDTO, Category>()
                .ForMember(e => e.ID, o => o.MapFrom(x => x.ID))
                .ForMember(e => e.Name, o => o.MapFrom(x => x.Name))
                .ForMember(e => e.Description, o => o.MapFrom(x => x.Description))
                .ForAllOtherMembers(e => e.Ignore());

                m.CreateMap<SubCategory, CategoryDTO>()
                .ForMember(e => e.ID, o => o.MapFrom(x => x.ID))

                .ForMember(e => e.Name, o => o.MapFrom(x => x.Name))
                .ForMember(e => e.Description, o => o.MapFrom(x => x.Description))
                .ForMember(e => e.Image, o => o.MapFrom(s => new ImageDTO { ID = s.Image.ID, ImageURL = s.Image.ImageURL }))
                .ForAllOtherMembers(e => e.Ignore());

                m.CreateMap<CategoryDTO, SubCategory>()
                                .ForMember(e => e.ID, o => o.MapFrom(x => x.ID))
                                .ForMember(e => e.Name, o => o.MapFrom(x => x.Name))
                .ForMember(e => e.Description, o => o.MapFrom(x => x.Description))
            .ForAllOtherMembers(e => e.Ignore());
                #endregion

                #region Sale listing Mapping
                m.CreateMap<SaleListing, SaleListingCreateDTO>()
                  //.ForMember(e => e.ProductCategoryID, o => o.MapFrom(s => s.ProductCategory.ID))
                  .ForMember(e => e.Images, o => o.MapFrom(s => (s.Images.Select(b => new ImageDTO { ImageURL = b.ImageURL, ID = b.ID }))))
                  .ForMember(e => e.ProductID, o => o.MapFrom(s => s.Product.ID))
                  .ForMember(e => e.ManufacturerID, o => o.MapFrom(s => s.Product.Manufacturer.ID))
                  .ForMember(e => e.ManufacturerName, o => o.MapFrom(s => s.Product.Manufacturer.Name))
                  .ForMember(e => e.ProductName, o => o.MapFrom(s => s.Product.Name))
                .ForMember(e => e.CreatedById, o => o.MapFrom(s => s.CreatedBy.ID))
            .ForAllOtherMembers(e => e.Ignore());

                m.CreateMap<SaleListingCreateDTO, SaleListing>()
                    .ForMember(e => e.Category, o => o.MapFrom(s => new Category { ID = s.ProductCategoryID }))
                    .ForMember(e => e.CreatedBy, o => o.MapFrom(s => new Account { ID = s.CreatedById }))
                                          .ForMember(e => e.Images, o => o.MapFrom(s => (s.Images.Select(b => new ImageDTO { ImageURL = b.ImageURL, ID = b.ID }))))
                      .ForMember(e => e.Product, o => o.MapFrom(s => new ProductType { ID = s.ProductID, Name = s.ProductName, Manufacturer = new Manufacturer { ID = s.ManufacturerID, Name = s.ManufacturerName } }))
                        .ForMember(e => e.CreatedBy, o => o.MapFrom(s => new Account { ID = s.CreatedById }))
                    .ForAllOtherMembers(e => e.Ignore());

                m.CreateMap<SaleListing, SaleListingDTO>()
                                    .ForMember(e => e.ID, o => o.MapFrom(s => s.ID))
                    .ForMember(e => e.ManufacturerName, o => o.MapFrom(s => s.Product.Manufacturer.Name))
                    .ForMember(e => e.CompanyID, o => o.MapFrom(s => s.Owner.ID))
                    .ForMember(e => e.CompanyName, o => o.MapFrom(s => s.Owner.Name))
                    .ForMember(e => e.ProductName, o => o.MapFrom(s => s.Product.Name))
                    .ForMember(e => e.ProductID, o => o.MapFrom(s => s.Product.ID))
                    .ForMember(e => e.CreatedByFirstName, o => o.MapFrom(s => s.CreatedBy.FirstName))
                    .ForMember(e => e.CreatedByLastname, o => o.MapFrom(s => s.CreatedBy.LastName))
                    .ForMember(e => e.CreatedByID, o => o.MapFrom(s => s.CreatedBy.ID))
                      .ForMember(e => e.Images, o => o.MapFrom(s => (s.Images.Select(b => new ImageDTO { ImageURL = b.ImageURL, ID = b.ID }))))
                                      .ForAllOtherMembers(e => e.Ignore());


                m.CreateMap<SaleListingDTO, SaleListing>()
                    .ForMember(e => e.ID, o => o.MapFrom(s => s.ID))
                    .ForMember(e => e.Owner, o => o.MapFrom(s => new Company { ID = s.CompanyID, Name = s.CompanyName }))
                      .ForMember(e => e.Product, o => o.MapFrom(s => new ProductType { ID = s.ProductID, Name = s.ProductName, Manufacturer = new Manufacturer { Name = s.ManufacturerName } }))
                      .ForMember(e => e.Images, o => o.MapFrom(s => (s.Images.Select(b => new ImageDTO { ImageURL = b.ImageURL, ID = b.ID }))))
                                      .ForAllOtherMembers(e => e.Ignore());
                #endregion
                #region Image
                m.CreateMap<Image, ImageDTO>()

                    .ForMember(e => e.ID, o => o.MapFrom(s => s.ID))
                    .ForMember(e => e.ImageURL, o => o.MapFrom(s => s.ImageURL))
                .ForAllOtherMembers(e => e.Ignore());

                m.CreateMap<ImageDTO, Image>()
                .ForMember(e => e.ID, o => o.MapFrom(s => s.ID))
                .ForMember(e => e.ImageURL, o => o.MapFrom(s => s.ImageURL))
                .ForAllOtherMembers(e => e.Ignore());
                #endregion
                #region Product

                m.CreateMap<ProductType, ProductDTO>()
                    .ForMember(e => e.ID, o => o.MapFrom(s => s.ID))
                    .ForMember(e => e.Name, o => o.MapFrom(s => s.Name))
                    .ForMember(e => e.ProductCategoryID, o => o.MapFrom(s => s.Category.ID))
                    .ForMember(e => e.ManufacturerID, o => o.MapFrom(s => s.Manufacturer.ID))
                                    .ForAllOtherMembers(e => e.Ignore());

                m.CreateMap<ProductDTO, ProductType>()
                    .ForMember(e => e.ID, o => o.MapFrom(s => s.ID))
                    .ForMember(e => e.Name, o => o.MapFrom(s => s.Name))
                .ForAllOtherMembers(e => e.Ignore());
                #endregion

                #region Manufacturer
                m.CreateMap<ManufacturerDTO, Manufacturer>()
                .ForMember(e => e.Name, o => o.MapFrom(s => s.Name))
                .ForMember(e => e.Description, o => o.MapFrom(s => s.Description))
                                .ForAllOtherMembers(e => e.Ignore());
                m.CreateMap<Manufacturer, ManufacturerDTO>()
                .ForMember(e => e.Name, o => o.MapFrom(s => s.Name))
                .ForMember(e => e.Description, o => o.MapFrom(s => s.Description))
                .ForAllOtherMembers(e => e.Ignore());
                #endregion

                #region Rating

                m.CreateMap<Rating, RatingDTO>()
                    .ForMember(e => e.ID, o => o.MapFrom(s => s.ID))
                    .ForMember(e => e.Votes, o => o.MapFrom(s => s.Votes))
                    .ForMember(e => e.CompanyID, o => o.MapFrom(s => s.Company.ID))
                    .ForMember(e => e.Description, o => o.MapFrom(s => s.Description))
                    .ForMember(e => e.GivenRating, o => o.MapFrom(s => s.GivenRating))
                    .ForMember(e => e.CompanyImage, o => o.MapFrom(s => new ImageDTO { ImageURL = s.Company.Image!=null?s.Company.Image.ImageURL:null}))
                                    .ForAllOtherMembers(e => e.Ignore());

                m.CreateMap<RatingDTO, Rating>()
    .ForMember(e => e.ID, o => o.MapFrom(s => s.ID))
    .ForMember(e => e.Votes, o => o.MapFrom(s => s.Votes))
    .ForMember(e => e.Company, o => o.MapFrom(s => new Company { ID = s.CompanyID }))
    .ForMember(e => e.Description, o => o.MapFrom(s => s.Description))
    .ForMember(e => e.GivenRating, o => o.MapFrom(s => s.GivenRating))
                    .ForAllOtherMembers(e => e.Ignore());

                #endregion

            }
            );

            Mapper.AssertConfigurationIsValid();

        }
    }
}
