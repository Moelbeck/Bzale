using bzale.Common;

using bzale.ViewModel;
using System.Collections.Generic;

namespace bzale.WebService
{
    public interface ISaleListingWebService
    {
 
        bool CreateNewSaleListing(SaleListingCreateDTO model);

 
        SaleListingDTO GetSaleListingByID(int id);

 
        List<SaleListingDTO> GetSaleListingsForCompany(int companyID,int page, int size);

 
        List<SaleListingDTO> GetSaleListingsForCategory(int viewmodel, int page, int size);

 
        List<SaleListingDTO> GetSaleListingsBySearchString(string search, int page, int size, int userid);

        List<ImageDTO> GetImagesForSaleListing(int salelistingid);
        ImageDTO GetImageForSaleListing(int salelistingid);


        bool DeleteSaleListing(SaleListingDTO salelistingviewmodel);

        bool DeleteSaleListingByID(int saleID);

        bool UpdateSaleListing(SaleListingUpdateDTO viewmodel);

        bool AddImageSaleListing(SaleListingDTO viewmodel, ImageUploadDTO img);

        bool RemoveImageSaleListing(int salelistingid, int imageid);

        bool AddOrUpdateSubscription(eSubscription sub, SaleListingDTO salelistingviewmodel);

        bool AddComment(int salelistingid, CommentDTO commentviewmodel);

        bool AddAnswerForComment(int salelisting, int commentid, CommentDTO answerviewmodel);

        bool RemoveComment(SaleListingDTO saleviewmodel, int id);

   
        List<CommentDTO> GetCommentsForSaleListing(int salelistingID);
    }
}
