using Newtonsoft.Json;

namespace Acklann.Plaid.Asset
{
    /// <summary>
    /// Represents a request for plaid's '/asset_report/create' endpoint. The '/asset_report/create' endpoint allows developers to create an asset report for all accounts available to an access token.
    /// </summary>
    public class GetAssetReportPdfRequest : RequestBaseTokenless
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAssetReportPdfRequest"/> class.
        /// </summary>
        public GetAssetReportPdfRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAssetReportPdfRequest"/> class.
        /// </summary>
        /// <param name="assetReportToken">The access token for the required report.</param>
        public GetAssetReportPdfRequest(string assetReportToken) => AssetReportToken = assetReportToken;

        /// <summary>
        /// Gets or sets the asset report token.
        /// </summary>
        [JsonProperty("asset_report_token")]
        public string AssetReportToken { get; set; }

        ///// <summary>
        ///// Gets or sets whether to include insights (requires enabling by Plaid first), optional, false is default if omitted.
        ///// </summary>
        //[JsonProperty("include_insights")]
        //public bool IncludeInsights { get; set; } = false;
    }
}