using Newtonsoft.Json;

namespace Acklann.Plaid.Asset
{
    /// <summary>
    /// Represents a request for plaid's '/asset_report/get' endpoint. The '/asset_report/get' endpoint allows developers to fetch an existing asset report.
    /// </summary>
    public class GetAssetReportRequest : RequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAssetReportRequest"/> class.
        /// </summary>
        public GetAssetReportRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAssetReportRequest"/> class.
        /// </summary>
        public GetAssetReportRequest(string assetReportToken, bool includeInsights = false)
        {
            AssetReportToken = assetReportToken;
            IncludeInsights = includeInsights;
        }

        /// <summary>
        /// Gets or sets the asset report token.
        /// </summary>
        [JsonProperty("asset_report_token")]
        public string AssetReportToken { get; set; }

        /// <summary>
        /// Gets or sets whether to include insights (requires enabling by Plaid first), optional, false is default if omitted.
        /// </summary>
        [JsonProperty("include_insights")]
        public bool IncludeInsights { get; set; } = false;
    }
}