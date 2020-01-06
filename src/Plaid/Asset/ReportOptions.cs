using Newtonsoft.Json;

namespace Acklann.Plaid.Asset
{
    public partial class CreateAssetReportRequest
    {
        /// <summary>Represents report options.</summary>
        public class ReportOptions
        {
            /// <summary>Gets or sets the optional client report identifier.</summary>
            [JsonProperty("client_report_id")]
            public string ClientReportId { get; set; }

            /// <summary>Gets or sets the optional webhook to call when the asset report is ready.</summary>
            [JsonProperty("webhook")]
            public string WebHook { get; set; }

            /// <summary>The (optional) user details.</summary>
            [JsonProperty("user")]
            public Entity.User User { get; set; }
        }
    }
}