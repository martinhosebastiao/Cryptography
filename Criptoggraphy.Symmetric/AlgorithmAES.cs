using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Criptography.Symmetric
{
    public abstract class AlgorithmAES
    {
        static readonly byte[] IV = new byte[16];
        static byte[]? buffer;

        /// <summary>
        /// Encriptação de texto usando o Algoritmo simetrico AES
        /// </summary>
        /// <param name="plainText">Texto a ser encriptado</param>
        /// <param name="key">Chave a ser usada para encriptar</param>
        /// <returns>Retorna o texto que foi cifrado</returns>
        public static string Encrypt(string plainText, string key)
        {
            try
            {
                // Aplicar validações para o plainText e key
                // ...

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = IV;

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using MemoryStream memoryStream = new();
                    using CryptoStream cryptoStream = new(memoryStream, encryptor, CryptoStreamMode.Write);
                    using StreamWriter streamWriter = new(cryptoStream);

                    // Escrever os dados no fluxo de memoria
                    streamWriter.Write(plainText, Encoding.Unicode);
                    streamWriter.Close();

                    // Obter os bytes existentes no fluxo de memoria
                    buffer = memoryStream.ToArray();

                    plainText = Convert.ToBase64String(buffer);
                }

                return plainText;
            }
            catch (Exception ex)
            {
                return string.Concat("Erro: ", ex.Message);
            }
        }

        /// <summary>
        /// Desencriptando o texto cifrado usando o Algoritmo AES
        /// </summary>
        /// <param name="cipherText">Texto a ser desencriptado</param>
        /// <param name="key">Chave a ser usada para encriptar</param>
        /// <returns></returns>
        public static string Decrypt(string cipherText, string key)
        {
            try
            {
                // Aplicar validações para o cipherText e key
                // ...

                buffer = Convert.FromBase64String(cipherText);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = IV;

                    var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using MemoryStream memoryStream = new(buffer);
                    using CryptoStream cryptoStream = new(memoryStream, decryptor, CryptoStreamMode.Read);
                    using StreamReader streamReader = new(cryptoStream);

                    cipherText = streamReader.ReadToEnd();
                }
                return cipherText;
            }
            catch (Exception ex)
            {
                return string.Concat("Erro: ", ex.Message);
            }
        }
    }
}

