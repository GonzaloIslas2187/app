using System.Security.Cryptography;
using System.Text;

namespace App.Core.Utils
{
    public static class CryptographyHelper
    {
        public static string GetHash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                var sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }

        public static bool CompareHash(string incomingHash, string storedHash)
        {
            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(incomingHash, storedHash) == 0;
        }

        public static bool VerifyHash(string incomingUnHashed, string storedHash)
        {

            string incomingHash = CryptographyHelper.GetHash(incomingUnHashed);


            if (CryptographyHelper.CompareHash(incomingHash, storedHash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
