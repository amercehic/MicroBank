namespace MicroBank.Common.Repository
{
    public interface ICardRepository
    {
        public byte[] EncryptCardNumber(string plainText, byte[] Key, byte[] IV);
        public string DecryptCardNumber(byte[] cipherText, byte[] Key, byte[] IV);
    }
}
