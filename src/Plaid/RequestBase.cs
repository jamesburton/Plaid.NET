using Acklann.Plaid.Interfaces;
using Newtonsoft.Json;

namespace Acklann.Plaid
{
    /// <summary>Provides methods and properties for making a standard request.</summary>
    /// <seealso cref="RequestBaseTokenless" />
    /// <seealso cref="IHasAccessToken" />
    public abstract class RequestBase : RequestBaseTokenless, IHasAccessToken
    {
        /// <inheritdoc />
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}