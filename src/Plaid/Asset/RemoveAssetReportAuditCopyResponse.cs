namespace Acklann.Plaid.Asset
{
    /// <summary>
    /// Represents a response from plaid's '/asset_report/audit_copy/remove' endpoints. The '/asset_report/audit_copy/remove' endpoint allows you to remove an <see cref="Entity.AssetReport"/> audit-copy. Once removed, the access_token associated with the report is no longer valid and cannot be used to access the audit-copy of the report but the source report will remain unchanged.
    /// </summary>
    /// <seealso cref="ResponseBase" />
    public class RemoveAssetReportAuditCopyResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="Entity.AssetReport"/> audit-copy was removed/deleted.
        /// </summary>
        /// <value><c>true</c> if removed/deleted; otherwise, <c>false</c>.</value>
        public bool Removed { get; set; }
    }
}