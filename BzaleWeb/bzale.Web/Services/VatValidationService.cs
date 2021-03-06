﻿using bzale.Service;
using bzale.ViewModel;
using bzale.WebsiteService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzale.WebsiteService
{
    public class VatValidationService
    {
        private string URI = string.Format("{0}{1}", Konstanter.VATURI, "vat");
        private HttpBaseClient client;
        public VatValidationService()
        {
            client = new HttpBaseClient(URI);
        }

        #region GET
        public async Task<VatValidationDTO> GetVatValidation(string countrycode, string vatnr)
        {
            string uri = string.Format("?cc={0}&vatnr={1}", countrycode,vatnr);
            var vatvalidation = await client.GetResponseObject<VatValidationDTO, VatValidationDTO>(uri, eHttpMethodType.GET, null);
            return vatvalidation;
        }
        #endregion
    }
}
