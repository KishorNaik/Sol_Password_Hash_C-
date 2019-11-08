using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HashPassword
{

    public enum ByteRange
    {
        byte16 = 16,
        byte32 = 32,
        byte64 = 64,
        byte128 = 128,
        byte256 = 256
    };


    public static class Hash
    {
        public static async Task<String> CreateAsync(string password,string salt,ByteRange byteRange)
        {
            return await Task.Run(() => {

                return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                       password: password,
                       salt: Encoding.UTF8.GetBytes(salt),
                       prf: KeyDerivationPrf.HMACSHA1,
                       iterationCount: 10000,
                       //numBytesRequested: 256 / 8)
                       numBytesRequested: (int)byteRange / 8)
                    );

            });
        }

        
        public static async Task<bool> ValidateAsync(string password, string salt, string hash,ByteRange byteRange)
         => await CreateAsync(password, salt,byteRange) == hash;
    }
}
