using Newtonsoft.Json;

namespace Acklann.Plaid.Asset
{
    /// <summary>
    /// Represents a request for plaid's '/asset_report/remove' endpoints. The '/asset_report/remove' endpoint allows you to delete an <see cref="Entity.AssetReport"/>. Once deleted, the associated asset_report and any filtered and audit reports generated from it will unavailable.
    /// </summary>
    /// <seealso cref="RequestBase" />
    public class RemoveAssetReportRequest : RequestBase {
        /// <summary>Constructs an instance of RemoveAssetReportRequest. See also <see cref="RequestBase"/>.</summary>
        public RemoveAssetReportRequest() { }

        /// <summary>Constructs an instance of RemoveAssetReportRequest. See also <see cref="RequestBase"/>.</summary>
        public RemoveAssetReportRequest(string assetReportToken) { AssetReportToken = assetReportToken; }

        /// <summary>Gets or sets the asset report token for the asset report to be removed.</summary>
        [JsonProperty("asset_report_token")]
        public string AssetReportToken { get; set; }
    }
}