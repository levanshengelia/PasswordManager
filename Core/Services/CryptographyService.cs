using Core.Services.IServices;
using System.Security.Cryptography;
using System.Text;

#pragma warning disable CA1416 // Validate platform compatibility (This service will only work on windows machine)

namespace Core.Services
{
    public class CryptographyService : ICryptographyService
    {
        public string Encrypt(string plainText)
        {
            byte[] data = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(ProtectedData.Protect(data, null, DataProtectionScope.LocalMachine));
        }

        public string Decrypt(string encryptedText)
        {
            byte[] encryptedData = Convert.FromBase64String(encryptedText);
            byte[] decryptedData = ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.LocalMachine);

            if (decryptedData == null)
            {
                throw new CryptographicException("Decryption failed.");
            }

            return Encoding.UTF8.GetString(decryptedData);
        }

        public string HashWithSHA256(string plainText)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(plainText));

            var builder = new StringBuilder();
            for (var i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}

#pragma warning restore CA1416 // Validate platform compatibility