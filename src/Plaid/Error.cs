using Newtonsoft.Json;

namespace Acklann.Plaid
{
    /// <summary>
    /// A model for errors originating on Plaid.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// A broad categorization of the error. One of: INVALID_REQUEST, INVALID_INPUT, INSTITUTION_ERROR, RATE_LIMIT_EXCEEDED, API_ERROR, ITEM_ERROR, or ASSET_REPORT_ERROR.
        /// 
        /// Safe for programmatic use.
        /// </summary>
        [JsonProperty("error_type")]
        public string ErrorType { get; set; }

        /// <summary>
        /// The particular error code.Each error_type has a specific set of error_codes.
        /// 
        /// Safe for programmatic use.
        /// </summary>
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// A developer-friendly representation of the error code.
        /// 
        /// This may change over time and is not safe for programmatic use.
        /// </summary>
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// A user-friendly representation of the error code. null if the error is not related to user action.
        /// 
        /// This may change over time and is not safe for programmatic use.
        /// </summary>
        [JsonProperty("display_message")]
        public string /*nullable*/ DisplayMessage { get; set; }
    }
}
