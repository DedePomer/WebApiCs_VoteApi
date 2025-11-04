using System.Security.Cryptography;
using System.Text;

namespace Common.Helpers;

public static class HashHelper
{
    public static byte[] GetHashByString(string text)
    {
        byte[] hash;
        byte[] hashByte = Encoding.UTF8.GetBytes(text);
        
        using (SHA256 sha = SHA256.Create())
        {
            hash = sha.ComputeHash(hashByte);
        }

        return hash;
    }
}