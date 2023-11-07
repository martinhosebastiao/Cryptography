using Blowfish = BCrypt.Net.BCrypt;

namespace Criptography.Symmetric
{
    public sealed class BlowfishCipher
    {
        public static string Encrypt(string plainText)
        {
            try
            {
                var hash = Blowfish.HashPassword(plainText);

                return hash;
            }
            catch (Exception ex)
            {
                return string.Concat("Erro: ", ex.Message);
            }
        }

        public static bool Verify(string plainText, string cipherText)
        {
            try
            {
                var result = Blowfish.Verify(plainText, cipherText);

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

