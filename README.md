# Password Hash
[![Generic badge](https://img.shields.io/badge/Nuget-1.0.0-<COLOR>.svg)](https://www.nuget.org/packages/HashPassword/)

## A password hasher that generates a unique salt for each hash.

### Using Nuget Package Manger:
```
PM> Install-Package HashPassword -Version 1.0.0
```

### Using .Net CLI
```
> dotnet add package HashPassword --version 1.0.0
```

### Usage
```C#
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

        // Store Salt and Hash in Database.
        // Get Salt and Hash based on User Name

        // Validate Password with using salt and Hash
        var flag = await Hash.ValidateAsync("mak123", saltData, hashData,ByteRange.byte256);
        Console.WriteLine(flag);

    }).Wait();

}
```
