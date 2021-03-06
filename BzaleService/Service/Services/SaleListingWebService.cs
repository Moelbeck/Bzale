﻿using AutoMapper;
using depross.Common;
using depross.Interfaces;
using depross.Model;
using depross.Repository;
using depross.Repository.DatabaseContext;
using depross.service;
using depross.Service;
using depross.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace depross.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SaleListingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SaleListingService.svc or SaleListingService.svc.cs at the Solution Explorer and start debugging.
    public class SaleListingWebService : ISaleListingWebService
    {
    

        private ISaleListingRepository _saleListingRepository;
        private IMainCategoryRepository _categoryRepository;
        private IProductTypeRepository _productRepository;
        private IManufacturerRepository _manufacturerRepository;
        private IAccountRepository _accountRepository;
        private SubscriptionService _subscriptionService;
        private ImageService _imageService;
        private CreateAndUpdateService _createAndUpdateService;
        public SaleListingWebService( )
        {
            BzaleDatabaseContext context = new BzaleDatabaseContext();
            _saleListingRepository = new SaleListingRepository(context);
            _categoryRepository = new MainCategoryRepository(context);
            _productRepository = new ProductTypeRepository(context);
            _manufacturerRepository = new ManufacturerRepository(context);
            _accountRepository = new AccountRepository(context);
            _subscriptionService = new SubscriptionService();
            _imageService = new ImageService();
            _createAndUpdateService = new CreateAndUpdateService();
        }


        public bool CreateNewSaleListing(SaleListingDTO model)
        {
            try
            {

                Account acc = _accountRepository.GetAccount(model.CreatedBy.ID);
                if (acc.Company !=null && !string.IsNullOrEmpty(acc.Company.VAT))
                {
                    var sale = Mapper.Map<SaleListingDTO, SaleListing>(model);
                    var product = _productRepository.GetProductTypeByID(model.ProductType.ID);
                    var salelisting = _createAndUpdateService.CreateSaleListingObject(sale, acc, product);
                    salelisting = _saleListingRepository.AddSaleListing(salelisting);
                    return true;
                }
                return false;

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
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateSaleListing(SaleListingDTO viewmodel)
        {
            try
            {
                SaleListing updated = Mapper.Map<SaleListingDTO, SaleListing>(viewmodel);
                SaleListing current = _saleListingRepository.GetSaleListing(viewmodel.ID);
                current = _createAndUpdateService.UpdateSaleListingFields(current, updated);
                _saleListingRepository.UpdateSaleListing(current);
                return true;
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
                SaleListingDTO viewmodelmodel = Mapper.Map<SaleListing, SaleListingDTO>(salelisting);
                return viewmodelmodel;

            }
            catch (Exception ex)
            {

                throw;
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

                var salelistings = _saleListingRepository.GetSaleListingsBySearchString(search, page, size);
                //_log.LogSearch(userid, search);
                return salelistings.Select(Mapper.Map<SaleListing, SaleListingDTO>).ToList();
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
