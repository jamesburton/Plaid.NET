using Newtonsoft.Json;

namespace Acklann.Plaid.Entity
{
    public class Owner
    {
        [JsonProperty("addresses")]
        public Address[] Addresses { get; set; }

        [JsonProperty("emails")]
        public Email[] Emails { get; set; }

        [JsonProperty("names")]
        public string[] Names { get; set; }

        [JsonProperty("phone_numbers")]
        public Email[] PhoneNumbers { get; set; }
    }
}
