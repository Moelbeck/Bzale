using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace biz2biz.Extension
{
    public static class Validators
    {


        public static bool IsValidEmail( this string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email.Trim());
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPhoneNr( this string number)
        {
            return Regex.Match(number, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$").Success;
        }
    }
}
