using Newtonsoft.Json;

namespace Acklann.Plaid.Entity
{
    public class Email
    {
        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("primary")]
        public bool Primary { get; set; }

        [JsonProperty("type")] // NB: Could be made into an enum, examples include "primary", "secondary" and "other"
        public string Type { get; set; }
    }
}
