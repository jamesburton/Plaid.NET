using Newtonsoft.Json;

namespace Acklann.Plaid.Asset
{
    /// <summary>
    /// Represents a request for plaid's '/asset_report/refresh' endpoint. The '/asset_report/refresh' endpoint allows developers to copy an asset report with refreshed data (as asset reports are immutable).
    /// </summary>
    public class RefreshAssetReportRequest : RequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RefreshAssetReportRequest"/> class.
        /// </summary>
        public RefreshAssetReportRequest()
        {
        }

        /// <summary>Gets or sets the request options.</summary>
        [JsonProperty("options")]
        public RefreshAssetReportRequestOptions Options { get; set; }

        /// <summary>Gets or sets the number of days data to include (maximum=730).</summary>
        [JsonProperty("days_requested")]
        public int? DaysRequested { get; set; } // NB: Default to null to use previous value, or set to replace with new value (Maximum=730).

        /// <summary>
        /// Represents request options.
        /// </summary>
        public class RefreshAssetReportRequestOptions
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