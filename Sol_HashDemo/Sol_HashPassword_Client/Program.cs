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

                var password = "kishor11";

                var saltData = await Salt.CreateAsync(ByteRange.byte128);
                var hashData = await Hash.CreateAsync(password, saltData);

                var flag = await Hash.ValidateAsync("kishor11", saltData, hashData);

                Console.WriteLine(saltData);

                saltData = await Salt.CreateAsync(ByteRange.byte128);
                hashData = await Hash.CreateAsync(password, saltData);
                
                Console.WriteLine(saltData);

            
            }).Wait();

        }
    }
}
