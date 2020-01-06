//using Newtonsoft.Json;

namespace Acklann.Plaid.Asset
{
    /// <summary>
    /// Represents a response from plaid's '/asset_report/refresh' endpoint.
    /// </summary>
    /// <seealso cref="ResponseBase" />
    // public int AssetReportToken { get; set; }
    // public int AssetReportId { get; set; }
    public class RefreshAssetReportResponse : CreateAssetReportResponse { } // NB: These models match, so re-using
}