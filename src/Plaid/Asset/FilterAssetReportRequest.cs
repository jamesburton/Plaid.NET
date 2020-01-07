using Newtonsoft.Json;

namespace Acklann.Plaid.Asset
{
    /// <summary>
    /// Represents a request for plaid's '/asset_report/refresh' endpoint. The '/asset_report/refresh' endpoint allows developers to copy an asset report with refreshed data (as asset reports are immutable).
    /// </summary>
    public class FilterAssetReportRequest : RequestBaseTokenless
    {
        /// <summary>Initializes a new instance of the <see cref="FilterAssetReportRequest"/> class.</summary>
        public FilterAssetReportRequest()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="FilterAssetReportRequest"/> class.</summary>
        public FilterAssetReportRequest(string assetReportToken, params string[] accountIdsToExclude)
        {
            AssetReportToken = assetReportToken;
            AccountIdsToExclude = accountIdsToExclude;
        }

        /// <summary>Gets or sets the asset report token for the asset report to be filtered.</summary>
        [JsonProperty("asset_report_token")]
        public string AssetReportToken { get; set; }

        /// <summary>Gets or sets the list of account ids to also exclude (in addition to prior filtering) from the generated asset report.</summary>
        [JsonProperty("account_ids_to_exclude")]
        public string[] AccountIdsToExclude { get; set; }
    }
}