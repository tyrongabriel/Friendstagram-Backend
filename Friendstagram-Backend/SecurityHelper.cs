using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Friendstagram_Backend
{
    public class SecurityHelper
    {
        // https://stackoverflow.com/questions/13378815/base64-length-calculation Length Calc. Needed --> 60 is the String Length
        public const int SaltLength = (60/4) * 3;
        public const int SHA256Length = (64 / 4) * 3;

        public string CreateSalt()
        {
            var saltBytes = new byte[SaltLength];
            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        public string CreateSha256Hash(string input, string salt)
        {
            // !!! Needs to be length multiple of 4
            string SHA256String = input + salt;
            if (SHA256String.Length % 4 != 0)
            {
                int neededChars = (4 - (SHA256String.Length % 4));
                SHA256String += string.Concat(Enumerable.Repeat("=", Math.Min(neededChars,2)));

            }
            var SHA256Bytes = Convert.FromBase64String(SHA256String);
            using (var SHA256Manager = new SHA256Managed())
            {
                var hash = SHA256Manager.ComputeHash(SHA256Bytes);

                return Convert.ToBase64String(hash);
            }
        }

        public string CreateVerifcationCode()
        {
            var verificationBytes = new byte[(30 / 4) * 3];
            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetBytes(verificationBytes);
            }
            return Encoding.ASCII.GetString(verificationBytes);
        }
    }
}
