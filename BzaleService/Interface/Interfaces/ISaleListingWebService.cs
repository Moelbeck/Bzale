
using depross.Common;
using depross.ViewModel;
using System.Collections.Generic;

namespace depross.Interfaces
{
    public interface ISaleListingWebService
    {
 
        bool CreateNewSaleListing(SaleListingDTO model);

 
        SaleListingDTO GetSaleListingByID(int id);

 
        List<SaleListingDTO> GetSaleListingsForCompany(int companyID,int page, int size);

 
        List<SaleListingDTO> GetSaleListingsForCategory(int viewmodel, int page, int size);

 
        List<SaleListingDTO> GetSaleListingsBySearchString(string search, int page, int size, int userid);

        List<ImageDTO> GetImagesForSaleListing(int salelistingid);
        ImageDTO GetImageForSaleListing(int salelistingid);

        bool DeleteSaleListingByID(int saleID);

        bool UpdateSaleListing(SaleListingDTO viewmodel);

        bool AddImageSaleListing(SaleListingDTO viewmodel, ImageUploadDTO img);

        bool RemoveImageSaleListing(int salelistingid, int imageid);

        bool AddOrUpdateSubscription(eSubscription sub, SaleListingDTO salelistingviewmodel);

        bool AddComment(int salelistingid, CommentDTO commentviewmodel);

        bool AddAnswerForComment(int salelisting, int commentid, CommentDTO answerviewmodel);

        bool RemoveComment(SaleListingDTO saleviewmodel, int id);

   
        List<CommentDTO> GetCommentsForSaleListing(int salelistingID);
    }
}
