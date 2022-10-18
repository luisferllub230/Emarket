
using System.Security.Cryptography;
using System.Text;

namespace E_Market.Core.Application.Helper
{
    public class PasswordEncrypted
    {
        public static string ComputeSHA256Hash(string password) 
        {
            using (SHA256 sha256Hash = SHA256.Create()) 
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                //combert bytes to array
                StringBuilder builder = new();
                for (var i = 0; i < bytes.Length; i++) 
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
