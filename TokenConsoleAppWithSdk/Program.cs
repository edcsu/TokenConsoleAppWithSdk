using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace TokenConsoleAppWithSdk
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Getting token from AuthService");

            var settings = new AuthServiceSettings
            {
                ApiName = string.Empty,
                Authority = string.Empty,
                ClientId = string.Empty,
                ClientSecret = string.Empty
            };

            Console.WriteLine($"Accessing: {settings.Authority}");

            var tokenDetails = await TokenHelper.GetNewTokenAsync(settings);
            Console.WriteLine($"Access token: {tokenDetails!.AccessToken}");
            Console.WriteLine($"Expires In: {tokenDetails.ExpiresIn} seconds");
            Console.WriteLine($"TokenType: {tokenDetails.TokenType}");
            Console.WriteLine($"Scope: {tokenDetails.Scope}");
        }
    }
}
