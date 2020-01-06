//using Newtonsoft.Json;

namespace Acklann.Plaid.Asset
{
    /// <summary>
    /// Represents a response from plaid's '/asset_report/create' endpoint.
    /// </summary>
    /// <seealso cref="ResponseBase" />
    //public class FilterAssetReportResponse : ResponseBase
    //{
    //    /// <summary>
    //    /// Gets or sets the asset report token (used to get asset reports).
    //    /// </summary>
    //    [JsonProperty("asset_report_token")]
    //    public int AssetReportToken { get; set; }

    //    /// <summary>
    //    /// Gets or sets the asset report identifier (used to identify webhooks).
    //    /// </summary>
    //    [JsonProperty("asset_report_id")]
    //    public int AssetReportId { get; set; }
    //}
    public class FilterAssetReportResponse : CreateAssetReportResponse { } // NB: These models match, so re-using
}