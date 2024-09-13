using System.Security.Cryptography;

namespace PasswordHashing;

class Program
{

    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 100000;

    private  static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;

    //Driver code
    static void Main(string[] args)
    {
        Console.WriteLine(Hash( "password"));
        Console.ReadKey();
    }


    public static string Hash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);

     return Convert.ToHexString(hash)+" "+ Convert.ToHexString(salt);
 
    }
}

