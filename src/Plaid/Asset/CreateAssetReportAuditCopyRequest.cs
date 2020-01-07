using Newtonsoft.Json;

namespace Acklann.Plaid.Asset
{
    /// <summary>
    /// Represents a request for plaid's '/asset_report/audit_copy/create' endpoints. The '/asset_report/audit_copy/create' endpoint allows you to create a copy of an asset report with its own token, to share with auditors.
    /// </summary>
    /// <seealso cref="RequestBase" />
    public class CreateAssetReportAuditCopyRequest : RequestBaseTokenless {
        /// <summary>Constructs an instance of RemoveAssetReportRequest. See also <see cref="RequestBase"/>.</summary>
        public CreateAssetReportAuditCopyRequest() { }

        /// <summary>Constructs an instance of RemoveAssetReportRequest. See also <see cref="RequestBase"/>.</summary>
        /// <param name="assetReportToken">The token for the asset-report to be copied.</param>
        /// <param name="auditorId">The identifier for the auditor to be shared with.</param>
        public CreateAssetReportAuditCopyRequest(string assetReportToken, string auditorId) 
        { 
            AssetReportToken = assetReportToken;
            AuditorId = auditorId;
        }

        /// <summary>Gets or sets the asset report token for the asset report to be copied.</summary>
        [JsonProperty("asset_report_token")]
        public string AssetReportToken { get; set; }

        /// <summary>Gets or sets the identifier of the auditor to copy the report for.</summary>
        [JsonProperty("auditor_id")]
        public string AuditorId { get; set; }
    }
}