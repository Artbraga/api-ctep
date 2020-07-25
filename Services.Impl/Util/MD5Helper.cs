using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Services.Impl.Util
{
    public class MD5Helper
    {
        private static MD5 _md5Hash;
        static MD5 md5Hash { get
            {
                if(_md5Hash == null)
                {
                    _md5Hash = MD5.Create();
                }
                return _md5Hash;
            } 
        }
        public static string GetMd5Hash(string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

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
}
