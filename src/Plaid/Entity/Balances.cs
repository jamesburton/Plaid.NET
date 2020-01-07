using Newtonsoft.Json;

namespace Acklann.Plaid.Entity
{
    public class Balances
    {
        [JsonProperty("available")]
        public long? Available { get; set; }

        [JsonProperty("current")]
        public double Current { get; set; }

        [JsonProperty("iso_currency_code")]
        public string IsoCurrencyCode { get; set; }

        [JsonProperty("limit")]
        public double? Limit { get; set; }

        [JsonProperty("unofficial_currency_code")]
        public string UnofficialCurrencyCode { get; set; }
    }
}
