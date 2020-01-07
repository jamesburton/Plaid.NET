using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acklann.Plaid.Entity
{
    public class HistoricalBalance
    {
        [JsonProperty("current")]
        public double Current { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("iso_currency_code")]
        public string IsoCurrencyCode { get; set; }

        [JsonProperty("unofficial_currency_code")]
        public string UnofficialCurrencyCode { get; set; }
    }
}
