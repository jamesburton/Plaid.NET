using Newtonsoft.Json;

namespace Acklann.Plaid.Entity
{
    public class AddressData
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }
    }
}
