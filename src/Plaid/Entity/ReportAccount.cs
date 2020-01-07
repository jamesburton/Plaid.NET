using Newtonsoft.Json;

namespace Acklann.Plaid.Entity
{
    public class ReportAccount
    {
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("balances")]
        public Balances Balances { get; set; }

        [JsonProperty("days_available")]
        public long DaysAvailable { get; set; }

        [JsonProperty("historical_balances")]
        public HistoricalBalance[] HistoricalBalances { get; set; }

        [JsonProperty("mask")]
        public string Mask { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("official_name")]
        public string OfficialName { get; set; }

        [JsonProperty("owners")]
        public Owner[] Owners { get; set; }

        [JsonProperty("subtype")]
        public string Subtype { get; set; }

        [JsonProperty("transactions")]
        public Transaction[] Transactions { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
