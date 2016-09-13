using bzale.ViewModel;
using bzale.WebsiteService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace bzale.Core.ServiceHost.Validation
{
    public class VatValidationService
    {
        private string accountURI = @"http://www.apilayer.net/api/validate?access_key=16c8e27aeb837ec2dbeb06b07b71d951";
        private HttpBaseClient client;
        public VatValidationService()
        {
            client = new HttpBaseClient(accountURI);
        }

        #region GET

        public async Task<CompanyDTO> GetCompanyInformation(string vat,string countrycode)
        {
            string concatenatedVAT = string.Format("{0}{1}",countrycode, vat);
            string uri = string.Format("&vat_number={1}", concatenatedVAT);
            var user = await client.GetResponseObject<CompanyDTO, CompanyDTO>(uri, eHttpMethodType.GET, null);
            return user;
        }
        #endregion
    }
}
