using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Helpers {
    public static class HashHelper {
        public static string ComputeHash(string plainText, byte[] salt) {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] plainTextBytesWithSalt = new byte[plainTextBytes.Length + salt.Length];

            for (int i = 0; i < plainTextBytes.Length; i++) {
                plainTextBytesWithSalt[i] = plainTextBytes[i];
            }

            for (int i = 0; i < salt.Length; i++) {
                plainTextBytesWithSalt[plainTextBytes.Length + i] = salt[i];
            }

            HashAlgorithm hash = new SHA256CryptoServiceProvider();

            byte[] hashBytes = hash.ComputeHash(plainTextBytesWithSalt);

            return BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToUpper();
        }

        public static byte[] GetSalt() {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            Random rand = new Random();

            byte[] salt = new byte[rand.Next(8, 16)];
            rng.GetBytes(salt);

            return salt;
        }

        public static bool CheckHash(string hash, string plainText, byte[] salt) {
            string computedHash = ComputeHash(plainText, salt);
            return hash == computedHash;
        }
    }
}
