using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bzale.Common
{
    public enum eAccountType
    {
        None=0,
        Administrator=1,
        Owner =2,
        Worker=4
    }
    public enum eRating
    {
       None =0,
       One =1,
       Two = 2,
       Three =3,
       Four = 4,
       Five =5
    }
    public enum eCommentType
    {
        None=0,
        Rating =1,
        SaleListing =2
    }
    public enum eGender
    {
        [Display(Name = "Ukendt")]
        None = 0,
        [Display(Name="Mand")]
        Male=1,
        [Display(Name = "Kvinde")]
        Female = 2
    }
    public enum eAmountType
    {
        None=0,
        KG=1,
        Tonnes=2,
        Stk=4,
        Litre=8,
        Meter=16
    }
    public enum eImageType
    {
        None=0,
        SaleListing = 1,
        Category=2,
        Advertisement=4,
        CompanyImage=8
    }

    public enum eSubscription
    {
        None=0,
        Basic=1, //Giver en uge som fremhævet annonce
        Medium=2, //Giver en uge som fremhævet annonce, samt to dage i top galleri
        Premium=4, // Giver som Medium, samt top annonce og forside
    }

    public enum eSubscriptionType
    {
        None=0,
        SaleListing=1,
        Account=2
    }

    public enum eJobType
    {
        None=0,
        Murer = 1,
        Tømrer = 2,
        Smed =4,
        Kontor = 8,
        Lager = 16,

    }

    public enum eLogSaleListingType
    {
        None =0,
        Created =1,
        Update =2,
        Deleted=4,
        Search=8,
            Comment = 16
    }

    public enum eLoginType
    {
        None=0,
        Login=1,
        Logout=2,
        Created=4,
        Deleted=8
    }

    [Flags]
    public enum SaleListingType
    {
        None,
        Bed,
        Bricks,


        Car,
        Chair,
        Computer,
        Cabinet,

        Door,

        Folder,

        Sand,
        Screen,
        Shelf,
        Soil,
        Stones,
        
        Table,
        Telephone

    }
}
