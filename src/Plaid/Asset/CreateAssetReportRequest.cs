using Newtonsoft.Json;

namespace Acklann.Plaid.Asset
{
    /// <summary>
    /// Represents a request for plaid's '/asset_report/create' endpoint. The '/asset_report/create' endpoint allows developers to create an asset report for all accounts available to an access token.
    /// </summary>
    public partial class CreateAssetReportRequest : RequestBaseTokenless
    {
        /// <summary>Initializes a new instance of the <see cref="CreateAssetReportRequest"/> class.</summary>
        public CreateAssetReportRequest(params string[] accessTokens) => AccessTokens = accessTokens;

        /// <summary>Gets or sets the report options.</summary>
        /// <value>The report options.</value>
        [JsonProperty("options")]
        public ReportOptions Options { get; set; }

        /// <summary>Gets or sets the number of days data to include.</summary>
        /// <value>The pagination options.</value>
        [JsonProperty("days_requested")]
        public int DaysRequested { get; set; } = 730; // NB: Default to the maximum of 730 days.

        /// <summary>Gets or sets the list of access tokens, one for each <see cref="Entity.Item" /> to include in the report.</summary>
        /// <value>The access tokens.</value>
        [JsonProperty("access_tokens")]
        public string[] AccessTokens { get; set; }
    }
}