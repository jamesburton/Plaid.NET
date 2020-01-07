using Newtonsoft.Json;

namespace Acklann.Plaid.Entity
{
    public class Address
    {
        [JsonProperty("data")]
        public AddressData Data { get; set; }

        [JsonProperty("primary")]
        public bool Primary { get; set; }
    }
}
