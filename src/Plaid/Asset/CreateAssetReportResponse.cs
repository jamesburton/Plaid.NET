using Acklann.Plaid.Entity;
using Newtonsoft.Json;

namespace Acklann.Plaid.Asset
{
    /// <summary>
    /// Represents a response from plaid's '/asset_report/create' endpoint.
    /// </summary>
    /// <seealso cref="ResponseBase" />
    public class CreateAssetReportResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the asset report token (used to get asset reports).
        /// </summary>
        [JsonProperty("asset_report_token")]
        public string AssetReportToken { get; set; }

        /// <summary>
        /// Gets or sets the asset report identifier (used to identify webhooks).
        /// </summary>
        [JsonProperty("asset_report_id")]
        public string AssetReportId { get; set; }
    }
}