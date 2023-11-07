namespace Criptography.Symmetric;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Criptografia usando Algoritmo Blowfish!\n");

      
        const string plainText = ".NET Core é vida!";

        var cipherText = BlowfishCipher.Encrypt(plainText);
        var result = BlowfishCipher.Verify(plainText,cipherText);

        Console.WriteLine("Texto Legivel ==> {0}\n",plainText);
        Console.WriteLine("Transformado em Hash ==> {0}\n", cipherText);
        Console.WriteLine("A Hash é valida? ==> {0}\n", result);

        Console.ReadKey();

    }
}

