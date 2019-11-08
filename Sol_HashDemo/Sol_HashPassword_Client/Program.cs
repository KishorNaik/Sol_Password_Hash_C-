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

                // Set Plain Password Text
                var password = "mak123";

                // Generate Unique Salt as per the byte Range
                var saltData = await Salt.CreateAsync(ByteRange.byte256);
                Console.WriteLine(saltData);

                // Generate Hash 
                var hashData = await Hash.CreateAsync(password, saltData,ByteRange.byte256);
                Console.WriteLine(hashData);

                // Code Emit
                // Store Salt and Hash in Database.
                // Get Salt and Hash based on User Name

                // Validate Password with using salt and Hash
                var flag = await Hash.ValidateAsync("mak123", saltData, hashData,ByteRange.byte256);
                Console.WriteLine(flag);
                

               
            
            }).Wait();

        }
    }
}
