using HashPassword;
using System;
using System.Threading.Tasks;

namespace Sol_HashPassword_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Task.Run(async () => {

                var password = "mak123";

                var saltData = await Salt.CreateAsync(ByteRange.byte256);
                Console.WriteLine(saltData);

                var hashData = await Hash.CreateAsync(password, saltData,ByteRange.byte256);
                Console.WriteLine(hashData);

                var flag = await Hash.ValidateAsync("mak123", saltData, hashData,ByteRange.byte256);
                Console.WriteLine(flag);
                

               
            
            }).Wait();

        }
    }
}
