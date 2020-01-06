using Newtonsoft.Json;

namespace Acklann.Plaid.Asset
{
    /// <summary>
    /// Represents a request for plaid's '/asset_report/audit_copy/remove' endpoints. The '/asset_report/audit_copy/remove' endpoint allows you to delete an audit-copy of an <see cref="Entity.AssetReport"/>. Once deleted, the audit-copy will unavailable but the original asset report will remain unchanged.
    /// </summary>
    /// <seealso cref="RequestBase" />
    public class RemoveAssetReportAuditCopyRequest : RequestBase {
        /// <summary>Constructs an instance of RemoveAssetReportAuditCopyRequest. See also <see cref="RequestBase"/>.</summary>
        public RemoveAssetReportAuditCopyRequest() { }

        /// <summary>Constructs an instance of RemoveAssetReportAuditCopyRequest. See also <see cref="RequestBase"/>.</summary>
        public RemoveAssetReportAuditCopyRequest(string auditCopyToken) { AuditCopyToken = auditCopyToken; }

        /// <summary>Gets or sets the audit-copy asset report token for the audit-copy report to be removed.</summary>
        [JsonProperty("asset_report_token")]
        public string AuditCopyToken { get; set; }
    }
}