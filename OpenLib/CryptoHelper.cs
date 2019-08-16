using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace OpenLib
{
    class CryptoHelper
    {
        public static string GenerateSalt(int length)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[length];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public static string GenerateSalt()
        {
            return GenerateSalt(64);
        }

        public static string GenerateHash(string data, string salt)
        {
            HashAlgorithm hash_algo = new SHA512Managed();
            
            byte[] bdata = new byte[data.Length + salt.Length];

            for(int i = 0; i<data.Length; i++)
            {
                bdata[i] = Convert.ToByte(data[i]);
            }

            for(int i = 0; i<salt.Length; i++)
            {
                bdata[data.Length + i] = Convert.ToByte(salt[i]);
            }

            byte[] hash = hash_algo.ComputeHash(bdata);
            return Convert.ToBase64String(hash);
        }

        public static bool CheckPassword(string pw, string hash, string salt)
        {
            string hash1 = CryptoHelper.GenerateHash(pw, salt);

            if (hash1 == hash)
                return true;
            else
                return false;
        }
    }
}
