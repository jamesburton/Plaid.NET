using Newtonsoft.Json;

namespace Acklann.Plaid.Entity
{
    /// <summary>The model for user details (such as to be included in the asset report).</summary>
    public class User
    {
        /// <summary>Gets or sets the optional client user identifier.</summary>
        [JsonProperty("client_user_id")]
        public string ClientUserId { get; set; }

        /// <summary>Gets or sets the optional first name.</summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>Gets or sets the optional middle name.</summary>
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        /// <summary>Gets or sets the optional last  name.</summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>Gets or sets the optional SSN.</summary>
        [JsonProperty("ssn")]
        public string SSN { get; set; }

        /// <summary>Gets or sets the optional phone number 
        /// (Format: “+{country_code}{area code and subscriber number}”
        /// e.g. “+14155555555” (known as E.164 format)).
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>Gets or sets the email.</summary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
