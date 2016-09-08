using bzale.Service.Enum;
using bzale.ViewModel;
using bzale.Web.Services.HttpBaseClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzale.Service.Services
{
    public class ManufacturerService
    {
        private string manuURI = string.Format("{0}{1}", Konstanter.BASEURI, "ManufacturerWeb/");
        private HttpBaseClient client;

        public ManufacturerService()
        {
            client = new HttpBaseClient(manuURI);
        }
        #region GET

        public async Task<List<ManufacturerDTO>> GetManufacturersInCategory(int id)
        {

            string uri = string.Format("category/{0}", id);
            var user = await client.GetResponseObject<List<ManufacturerDTO>, List<ManufacturerDTO>>(uri, eHttpMethodType.GET, null);
            return user;
        }
        public async Task<ManufacturerDTO> GetManufacturer(int id)
        {
            string uri = string.Format("{0}", id);
            var user = await client.GetResponseObject<ManufacturerDTO, ManufacturerDTO>(uri, eHttpMethodType.GET, null);
            return user;
        }

        public async Task<List<ProductDTO>> GetProductsByManufacturerID(int id)
        {
            string uri = string.Format("{0}/products", id);
            var user = await client.GetResponseObject<List<ProductDTO>, List<ProductDTO>>(uri, eHttpMethodType.GET, null);
            return user;
        }

        public async Task<ProductDTO> GetProductByID(int id)
        {

            string uri = string.Format("products/{0}", id);
            var user = await client.GetResponseObject<ProductDTO, ProductDTO>(uri, eHttpMethodType.GET, null);
            return user;
        }
        #endregion


        #region POST
        #endregion


        #region PUT
        #endregion


        #region DELETE
        #endregion
    }
}
