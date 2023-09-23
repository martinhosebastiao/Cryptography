namespace Criptography.Symmetric;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Criptografia usando Algoritmo AES!\n");

        // Chave a ser usada para encriptar e desencriptar.
        const string key = "b14ca5898a4e4133bbce2ea2315a1916";
        const string plainText = ".NET Core é vida!";

        var cipherText = AlgorithmAES.Encrypt(plainText, key);
        var decryptedText = AlgorithmAES.Decrypt(cipherText, key);

        Console.WriteLine("Texto Legivel ==> {0}\n",plainText);
        Console.WriteLine("Encriptado ==> {0}\n", cipherText);
        Console.WriteLine("Desencriptado ==> {0}\n", decryptedText);

        Console.ReadKey();

    }
}

