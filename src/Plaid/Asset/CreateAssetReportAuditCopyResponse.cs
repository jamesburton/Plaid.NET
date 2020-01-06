using Newtonsoft.Json;

namespace Acklann.Plaid.Asset
{
    /// <summary>
    /// Represents a response from plaid's '/asset_report/audit_copy/create' endpoint.
    /// </summary>
    /// <seealso cref="ResponseBase" />
    public class CreateAssetReportAuditCopyResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the audit-copy token (used to get the audit-copy of the asset report).
        /// </summary>
        [JsonProperty("audit_copy_token")]
        public int AuditCopyToken { get; set; }
    }
}