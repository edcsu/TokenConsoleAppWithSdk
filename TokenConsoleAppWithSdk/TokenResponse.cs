using System;
using System.Collections.Generic;
using System.Text;

namespace TokenConsoleAppWithSdk
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }

        public string Scope { get; set; }

        public string TokenType { get; set; }

        public int ExpiresIn { get; set; }
    }
}
