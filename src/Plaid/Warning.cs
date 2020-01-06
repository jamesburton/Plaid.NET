using Newtonsoft.Json;

namespace Acklann.Plaid
{
    /// <summary>The asset report warning model.</summary>
    public class Warning
    {
        /// <summary>The warning type (NB: always "ASSET_REPORT_WARNING" according to asset report routine, and not currently seen elsewhere).</summary>
        [JsonProperty("warning_type")]
        public string WarningType { get; set; }

        [JsonProperty("warning_code")]
        public string WarningCode { get; set; }

        [JsonProperty("cause")]
        public WarningCause Cause { get; set; }

        public class WarningCause
        {
            [JsonProperty("error")]
            public Error Error { get; set; }

            [JsonProperty("item_id")]
            public string ItemId { get; set; }
        }
    }
}
