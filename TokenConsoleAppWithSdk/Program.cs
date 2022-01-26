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

            // Build a config object, using env vars and JSON providers.
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            // Get AuthServiceSettings values from the config.
            var settings = config.GetRequiredSection(AuthServiceSettings.ConfigurationName).Get<AuthServiceSettings>();

            Console.WriteLine($"Accessing: {settings.Authority}");

            var tokenDetails = await TokenHelper.GetNewTokenAsync(settings);
            Console.WriteLine($"Access token: {tokenDetails!.AccessToken}");
            Console.WriteLine($"Expires In: {tokenDetails.ExpiresIn} seconds");
            Console.WriteLine($"TokenType: {tokenDetails.TokenType}");
            Console.WriteLine($"Scope: {tokenDetails.Scope}");
        }
    }
}
