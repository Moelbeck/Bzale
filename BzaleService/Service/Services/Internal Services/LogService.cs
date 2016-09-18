//using bzale.Common;
//using bzale.Model.Log;
//using bzale.Repository;
//using bzale.Repository.DatabaseContext;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace bzale.Service
//{
//    public class LogService
//    {
//        //private readonly LogRepository _logRepo;

//        public LogService(BzaleDatabaseContext context)
//        {
//            _logRepo = new LogRepository(context);
//        }


//        public void LogSaleListing(int userid, int salelistingID, eLogSaleListingType type)
//        {
//            LogUserSaleListing log = new LogUserSaleListing
//            {
//                UserID = userid,
//                SaleListingID = salelistingID,
//                LogType = type
//            };
//            _logRepo.LogSaleListing(log);
//        }

//        public void LogSearch(int userid, string search)
//        {
//            LogUserSearch log = new LogUserSearch
//            {
//                UserID = userid,
//                SearchString = search
//            };
//            _logRepo.LogSearch(log);
//        }

//        public void LogLoginLogout(int userid, eLoginType type)
//        {
//            LogUserLogin login = new LogUserLogin()
//            {
//                UserID = userid,
//                Type = type
//            };
//            _logRepo.LogUserLogin(login);
//        }
//    }
//}