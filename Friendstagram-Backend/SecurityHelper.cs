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
        public const int SaltLength = (64/4)*3;
        public const int SHA256Length = (64/4)*3;

        public string CreateSalt()
        {
            var saltBytes = new byte[SaltLength];
            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetHashCode();
                provider.GetBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        public string CreateSha256Hash(string input, string salt)
        {
            // !!! Needs to be length multiple of 4
            var inputBytes = ASCIIEncoding.ASCII.GetBytes(input);
            var saltBytes = Convert.FromBase64String(salt);
            IEnumerable<byte> combinedBytes = inputBytes.Concat(saltBytes);
            string SHA256String = Convert.ToBase64String(combinedBytes.ToArray());

            var SHA256Bytes = Convert.FromBase64String(SHA256String);
            using (var SHA256Manager = new SHA256Managed())
            {
                var hash = SHA256Manager.ComputeHash(SHA256Bytes);

                return Convert.ToBase64String(hash);
            }
        }

        public string CreateVerifcationCode()
        {
            var verificationBytes = new byte[16];
            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetBytes(verificationBytes);
            }
            return Convert.ToBase64String(verificationBytes);
        }
    }
}
