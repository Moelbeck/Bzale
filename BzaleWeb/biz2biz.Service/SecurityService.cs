using System;
using System.Security.Cryptography;
using System.Text;

namespace biz2biz.Service
{
    public class SecurityService
    {
        private readonly RNGCryptoServiceProvider _crypto;
        public SecurityService()
        {
            _crypto = new RNGCryptoServiceProvider();
        }

        public string GenerateCryptedPassword(string psw, string salt)
        {
            if (String.IsNullOrEmpty(psw) || String.IsNullOrEmpty(salt))
                // Något fel med inparametrarna. Kasta undantag
                throw new ArgumentException("Input is null or empty");

            try
            {
                SHA256 sha = SHA256.Create();

                string strPs = psw + salt;
                // Konvertera till byte array
                byte[] bPs = Encoding.Default.GetBytes(strPs);
                // Skapa hash
                byte[] bHashOfPassWord = sha.ComputeHash(bPs);
                // Konvertera byte array till string
                var strSafePassWord = Encoding.Default.GetString(bHashOfPassWord);

                return strSafePassWord;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public byte[] GenerateSalt()
        {
            byte[] bSalt = new byte[24];
            _crypto.GetBytes(bSalt);
            return bSalt;
        }

        public bool ValidatePassword(string psw, string cryptedpsw, string salt)
        {
            bool bValidPassWord = false;

            if (String.IsNullOrEmpty(psw) || String.IsNullOrEmpty(cryptedpsw) || String.IsNullOrEmpty(salt))
                // Något fel med inparametrarna. Kasta undantag
                throw new ArgumentException("Input is null or empty");

            try
            {
                // Vi har inparametrar
                // Skapa ett lösenord från det inmatade lösenordet och salt värde
                string strSafePassWord = GenerateCryptedPassword(psw, salt);

                if ((String.Compare(strSafePassWord, cryptedpsw) == 0))
                    bValidPassWord = true;

                return bValidPassWord;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
