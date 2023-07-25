using System.Security.Cryptography;
using ContactBookAPP.Authentication.Interface;

namespace ContactBookAPP.Authentication.Logic
{
    public class JWTSecretKeyGenerator : IJWTSecretKeyGenerator
    {
        public string GenerateJwtSecretKey(int keyLengthInBytes)
        {
            byte[] keyBytes = new byte[keyLengthInBytes];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetBytes(keyBytes);
            }

            // Convert the key to Base64 encoding
            string jwtSecretKey = Convert.ToBase64String(keyBytes);

            return jwtSecretKey;
        }
    }
}
