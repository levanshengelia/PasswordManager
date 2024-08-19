namespace Core.Services.IServices
{
    public interface ICryptographyService
    {
        public string Encrypt(string plainText, string key);
        public string Decrypt(string encryptedText, string key);
        public string HashWithSHA256(string plainText);
    }
}
