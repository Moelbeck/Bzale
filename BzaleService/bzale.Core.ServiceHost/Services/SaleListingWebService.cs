using AutoMapper;
using bzale.Common;
using bzale.Model;
using bzale.Repository;
using bzale.Repository.DatabaseContext;
using bzale.service;
using bzale.Service;
using bzale.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bzale.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SaleListingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SaleListingService.svc or SaleListingService.svc.cs at the Solution Explorer and start debugging.
    public class SaleListingWebService : ISaleListingWebService
    {
    

        private ISaleListingRepository _saleListingRepository;
        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;
        private IManufacturerRepository _manufacturerRepository;
        private IAccountRepository _accountRepository;
        private SubscriptionService _subscriptionService;
        private ImageService _imageService;
        private CreateAndUpdateService _createAndUpdateService;
        public SaleListingWebService(ISaleListingRepository saleRepo, ICategoryRepository catRepo, IProductRepository prodRepo, 
            IManufacturerRepository manuRepo, IAccountRepository accRepo )
        {
            _saleListingRepository = saleRepo;
            _categoryRepository = catRepo;
            _productRepository = prodRepo;

            _manufacturerRepository = manuRepo;
            _accountRepository = accRepo;
            _subscriptionService = new SubscriptionService();
            _imageService = new ImageService();
            _createAndUpdateService = new CreateAndUpdateService();
        }


        public bool CreateNewSaleListing(SaleListingCreateDTO model)
        {
            try
            {

                Account acc = _accountRepository.GetAccount(model.CreatedById);
                if (acc.Company.IsVerified)
                {
                    var product = _productRepository.GetProductByID(model.ProductID);
                    var category = _categoryRepository.GetCategory(product.Category.ID);
                    var salelisting = _createAndUpdateService.CreateSaleListingObject(model, acc, product, category);
                    salelisting = _saleListingRepository.AddSaleListing(salelisting);
                    //_log.LogSaleListing(salelisting.Owner.ID, salelisting.ID, eLogSaleListingType.Created);
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public SaleListingDTO GetSaleListingByID(int id)
        {
            try
            {
                var salelisting = _saleListingRepository.GetSaleListing(id);
                //_log.LogSaleListing(salelisting.Owner.ID, salelisting.ID, eLogSaleListingType.Search);
                SaleListingDTO viewmodelmodel = Mapper.Map<SaleListing, SaleListingDTO>(salelisting);
                return viewmodelmodel;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DeleteSaleListing(SaleListingDTO salelistingviewmodel)
        {
            try
            {
                SaleListing salelisting = Mapper.Map<SaleListingDTO, SaleListing>(salelistingviewmodel);
                _saleListingRepository.DeleteSaleListing(salelisting);
                //_log.LogSaleListing(salelisting.Owner.ID, salelisting.ID, eLogSaleListingType.Deleted);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteSaleListingByID(int saleID)
        {
            try
            {

                _saleListingRepository.DeleteSaleListing(saleID);
                //_log.LogSaleListing(0, saleID, eLogSaleListingType.Deleted);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateSaleListing(SaleListingUpdateDTO viewmodel)
        {
            try
            {
                SaleListing updated = Mapper.Map<SaleListingUpdateDTO, SaleListing>(viewmodel);
                SaleListing current = _saleListingRepository.GetSaleListing(viewmodel.ID);
                current = _createAndUpdateService.UpdateSaleListingFields(current, updated);
                _saleListingRepository.UpdateSaleListing(current);
                //_log.LogSaleListing(current.Owner.ID, current.ID, eLogSaleListingType.Update);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<SaleListingDTO> GetSaleListingsForCompany(int companyID, int page, int size)
        {
            try
            {
                var company = _saleListingRepository.GetSaleListingsForCompany(companyID, page, size);
                return company.Select(Mapper.Map<SaleListing, SaleListingDTO>).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SaleListingDTO> GetSaleListingsForCategory(int id, int page, int size)
        {
            try
            {
                var salelistings = _saleListingRepository.GetSaleListingsForCategory(id, page, size);
                return salelistings.Select(Mapper.Map<SaleListing, SaleListingDTO>).ToList();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<SaleListingDTO> GetSaleListingsBySearchString(string search, int page, int size, int userid)
        {
            try
            {
                var salelistings = _saleListingRepository.GetSaleListingsBySearchString(search, page, size);
                //_log.LogSearch(userid, search);
                return salelistings.Select(Mapper.Map<SaleListing, SaleListingDTO>).ToList();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #region Images
        public bool AddImageSaleListing(SaleListingDTO viewmodel, ImageUploadDTO img)
        {
            try
            {
                if (_imageService.ValidateExtension(img.FileName))
                {
                    string imgurl = _imageService.SaveImageToFolder(img);
                    Image image = new Image { ImageURL = imgurl, Type = img.ImageType };
                    SaleListing salelisting = _saleListingRepository.GetSaleListing(viewmodel.ID);
                    salelisting.Images.Add(image);
                    _saleListingRepository.UpdateSaleListing(salelisting);
                    //_log.LogSaleListing(salelisting.Owner.ID, salelisting.ID, eLogSaleListingType.Update);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool RemoveImageSaleListing(int salelistingid, int imageid)
        {
            try
            {
                SaleListing salelisting = _saleListingRepository.GetSaleListing(salelistingid);
                var image = salelisting.Images.FirstOrDefault(e => e.ID == imageid);
                if (image != null)
                {
                    salelisting.Images.Remove(image);
                    _imageService.RemoveImageFromFolder(image.ImageURL);
                    _saleListingRepository.UpdateSaleListing(salelisting);
                    //_log.LogSaleListing(salelisting.Owner.ID, salelisting.ID, eLogSaleListingType.Update);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public List<ImageDTO> GetImagesForSaleListing(int salelistingid)
        {
            try
            {
                var images = _saleListingRepository.GetSaleListing(salelistingid).Images;

                return images.Select(Mapper.Map<Image, ImageDTO>).ToList();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ImageDTO GetImageForSaleListing(int salelistingid)
        {
            try
            {

                var images = _saleListingRepository.GetSaleListing(salelistingid).Images;
                Image mainimage = null;
                if (images.Any()) { mainimage = images[0]; }
                return Mapper.Map<Image, ImageDTO>(mainimage);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region Subscription
        public bool AddOrUpdateSubscription(eSubscription sub, SaleListingDTO salelistingviewmodel)
        {
            try
            {

                SaleListing salelisting = _saleListingRepository.GetSaleListing(salelistingviewmodel.ID);
                Subscription subscription = _subscriptionService.CreateSubscription(sub);
                _saleListingRepository.UpdateSaleListingSubscription(salelisting, subscription);
                //_log.LogSaleListing(salelisting.Owner.ID, salelisting.ID, eLogSaleListingType.Update);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Comments
        public bool AddComment(int salelistingid, CommentDTO commentviewmodel)
        {
            try
            {
                SaleListing salelisting = _saleListingRepository.GetSaleListing(salelistingid);
                Comment comment = Mapper.Map<CommentDTO, Comment>(commentviewmodel);
                SaleListingComment(comment);
                salelisting.Comments.Add(comment);
                _saleListingRepository.UpdateSaleListing(salelisting);
                //_log.LogSaleListing(salelisting.Owner.ID, salelisting.ID, eLogSaleListingType.Comment);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool AddAnswerForComment(int salelistingID, int commentID, CommentDTO answerviewmodel)
        {
            try
            {

                SaleListing salelisting = _saleListingRepository.GetSaleListing(salelistingID);
                Comment comment = salelisting.Comments.Single(e => e.ID == commentID);
               
                CommentAnswer answer = Mapper.Map<CommentDTO, CommentAnswer>(answerviewmodel);

                comment.Answers.Add(answer);
                _saleListingRepository.UpdateSaleListing(salelisting);
                //_log.LogSaleListing(salelisting.Owner.ID, salelisting.ID, eLogSaleListingType.Comment);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool RemoveComment(SaleListingDTO saleviewmodel, int id)
        {
            try
            {

                SaleListing salelisting = _saleListingRepository.GetSaleListing(saleviewmodel.ID);

                var comment = salelisting.Comments.FirstOrDefault(e => e.ID == id);
                if (comment != null)
                {
                    salelisting.Comments.Remove(comment);
                    _saleListingRepository.UpdateSaleListing(salelisting);
                    //_log.LogSaleListing(salelisting.Owner.ID, salelisting.ID, eLogSaleListingType.Comment);
                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<CommentDTO> GetCommentsForSaleListing(int salelistingID)
        {
            try
            {

                SaleListing salelisting = _saleListingRepository.GetSaleListing(salelistingID);
                var comments = salelisting.Comments;
                List<CommentDTO> viewmodels = comments.Select(e => Mapper.Map<Comment, CommentDTO>(e)).ToList();

                return viewmodels;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region Private
        void SaleListingComment(Comment comment)
        {
            comment.CommentType = eCommentType.SaleListing;
        }

        #endregion
    }

}
