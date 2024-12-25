using Loyalty_System.Interfaces;

namespace Loyalty_System.Services
{
    public class ApiKeyValidation : IApiKeyValidation
    {
        private readonly IConfiguration _config;

        public ApiKeyValidation(IConfiguration config)
        {
            _config = config;
        }

        public bool IsValidApiKey(string userApiKey)
        {
            if (string.IsNullOrEmpty(userApiKey))
            {
                return false;
            }
            var apiKey = _config["ApiKey"];
            if (apiKey is null || !apiKey.Equals(userApiKey))
            {
                return false;
            }
            return true;
        }
    }
}
