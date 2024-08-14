namespace Core.Core.Services.IServices
{
    public interface ICryptoService
    {
        public string Encrypt(string plainText, string key);
        public string Decrypt(string encryptedText, string key);
    }
}
