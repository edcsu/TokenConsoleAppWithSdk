using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TokenConsoleAppWithSdk
{
    public static class TokenHelper
    {
        public static async Task<TokenResponse?> GetNewTokenAsync(AuthServiceSettings settings)
        {
            try
            {
                using var tokenClient = new HttpClient();
                var discoveryDoc = await tokenClient.GetDiscoveryDocumentAsync(settings.Authority);
                if (discoveryDoc.IsError)
                {
                    Console.WriteLine(discoveryDoc.Error);

                    throw new ApplicationException("Failed to reach auth server.");
                }

                var tokenResponse = await tokenClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = discoveryDoc.TokenEndpoint,
                    ClientId = settings.ClientId,
                    ClientSecret = settings.ClientSecret,
                    Scope = settings.AccessScope
                });

                if (tokenResponse.IsError)
                {
                    Console.WriteLine(tokenResponse.Error);
                }
                else
                {
                    var token = new TokenResponse 
                    {
                        AccessToken = tokenResponse.AccessToken,
                        ExpiresIn = tokenResponse.ExpiresIn,
                        Scope = tokenResponse.Scope,
                        TokenType = tokenResponse.TokenType 
                    };
                    return token;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }
    }
}
