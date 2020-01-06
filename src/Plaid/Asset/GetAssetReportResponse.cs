using Acklann.Plaid.Entity;
using Newtonsoft.Json;

namespace Acklann.Plaid.Asset
{
    /// <summary>Represents a response from plaid's '/asset_report/get' endpoint.</summary>
    /// <seealso cref="ResponseBase" />
    public class GetAssetReportResponse : ResponseBase
    {
        /// <summary>The report object.</summary>
        [JsonProperty("report")]
        public AssetReport Report { get; set; }

        /// <summary>The list of warnings generated.</summary>
        [JsonProperty("warnings")]
        public Warning[] Warnings { get; set; }
    }
}