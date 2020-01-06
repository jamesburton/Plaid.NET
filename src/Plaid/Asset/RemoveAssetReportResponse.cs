namespace Acklann.Plaid.Asset
{
    /// <summary>
    /// Represents a response from plaid's '/asset_report/remove' endpoints. The '/asset_report/remove' endpoint allows you to remove an <see cref="Entity.AssetReport"/>. Once removed, the access_token associated with the report is no longer valid and cannot be used to access any data that was associated with the <see cref="Entity.AssetReport"/>.
    /// </summary>
    /// <seealso cref="ResponseBase" />
    public class RemoveAssetReportResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="Entity.AssetReport"/> was removed/deleted.
        /// </summary>
        /// <value><c>true</c> if removed/deleted; otherwise, <c>false</c>.</value>
        public bool Removed { get; set; }
    }
}