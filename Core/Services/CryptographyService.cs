using Core.Services.IServices;
using System.Security.Cryptography;
using System.Text;

namespace Core.Services
{
    public class CryptographyService(string key) : ICryptographyService
    {
        public string Encrypt(string plainText)
        {
            var iv = new byte[16];
            byte[] array;

            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Get128BitString(key));
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using var memoryStream = new MemoryStream();
                using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                using (var streamWriter = new StreamWriter(cryptoStream))
                {
                    streamWriter.Write(plainText);
                }
                array = memoryStream.ToArray();
            }

            return Convert.ToBase64String(array);
        }

        public string Decrypt(string encryptedText)
        {
            var iv = new byte[16];
            var buffer = Convert.FromBase64String(encryptedText);

            using Aes aes = Aes.Create();

            aes.Key = Encoding.UTF8.GetBytes(Get128BitString(key));
            aes.IV = iv;

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using var memoryStream = new MemoryStream(buffer);
            using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using var streamReader = new StreamReader(cryptoStream);

            return streamReader.ReadToEnd();
        }

        private static string Get128BitString(string keyToConvert)
        {
            var b = new StringBuilder();

            for (var i = 0; i < 16; i++)
            {
                b.Append(keyToConvert[i % keyToConvert.Length]);
            }

            return b.ToString();
        }

        public string HashWithSHA256(string plainText)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));

                var builder = new StringBuilder();
                for (var i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
