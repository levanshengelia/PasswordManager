namespace Core.Services.IServices
{
    public interface ICryptographyService
    {
        public string Encrypt(string plainText);
        public string Decrypt(string encryptedText);
        public string HashWithSHA256(string plainText);
    }
}
