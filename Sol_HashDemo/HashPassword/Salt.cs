using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace HashPassword
{
    public static class Salt
    {
        public static async Task<String> CreateAsync(ByteRange byteRange)
        {
            return await Task.Run(() => {

                int byteRangeValue = (int)byteRange;

                byte[] randomBytes = new byte[byteRangeValue / 8];
                using (var generator = RandomNumberGenerator.Create())
                {
                    generator.GetBytes(randomBytes);
                    return Convert.ToBase64String(randomBytes);
                }

            });
        }
    }
}
