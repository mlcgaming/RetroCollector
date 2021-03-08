using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RetroCollector.Models;

namespace RetroCollector.Data.Management {
    public class PasswordManager {
        public static byte[] GenerateSaltHash() {
            byte[] salt = new byte[32];
            new RNGCryptoServiceProvider().GetBytes(salt);

            return salt;
        }
        public static string[] GeneratePasswordHash(string password) {
            byte[] salt = GenerateSaltHash();

            string[] passwordHash = new string[2];
            passwordHash[0] = Convert.ToBase64String(salt);

            byte[] plainTextBytes = Encoding.UTF8.GetBytes(password);
            byte[] plainTextPlusSalt = new byte[plainTextBytes.Length + salt.Length];

            for(int i = 0; i < plainTextBytes.Length; i++) {
                plainTextPlusSalt[i] = plainTextBytes[i];
            }

            for(int i = 0; i < salt.Length; i++) {
                plainTextPlusSalt[i + plainTextBytes.Length] = salt[i];
            }

            var sha256Service = SHA256.Create();
            byte[] hashBytes = sha256Service.ComputeHash(plainTextPlusSalt);
            byte[] hashPlusSaltBytes = new byte[hashBytes.Length + salt.Length];

            for(int i = 0; i < hashBytes.Length; i++) {
                hashPlusSaltBytes[i] = hashBytes[i];
            }

            for(int i = 0; i < salt.Length; i++) {
                hashPlusSaltBytes[i + hashBytes.Length] = salt[i];
            }

            passwordHash[1] = Convert.ToBase64String(hashPlusSaltBytes);

            return passwordHash;
        }
        public static string[] GeneratePasswordHash(byte[] salt, string password) {
            string[] passwordHash = new string[2];
            passwordHash[0] = Convert.ToBase64String(salt);

            byte[] plainTextBytes = Encoding.UTF8.GetBytes(password);
            byte[] plainTextPlusSalt = new byte[plainTextBytes.Length + salt.Length];

            for(int i = 0; i < plainTextBytes.Length; i++) {
                plainTextPlusSalt[i] = plainTextBytes[i];
            }

            for(int i = 0; i < salt.Length; i++) {
                plainTextPlusSalt[i + plainTextBytes.Length] = salt[i];
            }

            var sha256Service = SHA256.Create();
            byte[] hashBytes = sha256Service.ComputeHash(plainTextPlusSalt);
            byte[] hashPlusSaltBytes = new byte[hashBytes.Length + salt.Length];

            for(int i = 0; i < hashBytes.Length; i++) {
                hashPlusSaltBytes[i] = hashBytes[i];
            }

            for(int i = 0; i < salt.Length; i++) {
                hashPlusSaltBytes[i + hashBytes.Length] = salt[i];
            }

            passwordHash[1] = Convert.ToBase64String(hashPlusSaltBytes);

            return passwordHash;
        }

        public static bool CheckPassword(UserAccount user, string password) {
            
            string checkedPassword = GeneratePasswordHash(user.Salt, password)[1];

            if(checkedPassword == user.PassHash) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
