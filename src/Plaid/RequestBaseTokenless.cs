using Acklann.Plaid.Interfaces;
using Newtonsoft.Json;

namespace Acklann.Plaid
{
    /// <summary>Provides methods and properties for making a standard request.</summary>
    /// <seealso cref="SerializableContent" />
    /// <seealso cref="IHasClientIdAndSecret" />
    public abstract class RequestBaseTokenless : SerializableContent, IHasClientIdAndSecret
    {
        /// <inheritdoc />
        [JsonProperty("secret")]
        public string Secret { get; set; }

        /// <inheritdoc />
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
    }
}