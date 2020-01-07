
using Newtonsoft.Json;
using System;

namespace Acklann.Plaid.Entity
{
    public class ReportItem
    {
        [JsonProperty("accounts")]
        public ReportAccount[] Accounts { get; set; }

        [JsonProperty("date_last_updated")]
        public DateTimeOffset DateLastUpdated { get; set; }

        [JsonProperty("institution_id")]
        public string InstitutionId { get; set; }

        [JsonProperty("institution_name")]
        public string InstitutionName { get; set; }

        [JsonProperty("item_id")]
        public string ItemId { get; set; }
    }
}

//using Newtonsoft.Json;
//using System;

//namespace Acklann.Plaid.Entity
//{
//    public partial class AssetReport
//    {
//        /// <summary>The model for report items.</summary>
//        public class ReportItem
//        {
//            /// <summary>The item identifier.</summary>
//            [JsonProperty("item_id")]
//            public string ItemId { get; set; }

//            /// <summary>The institution name.</summary>
//            [JsonProperty("institution_name")]
//            public string InstitutionName { get; set; }

//            /// <summary>The institution identifier.</summary>
//            [JsonProperty("institution_id")]
//            public string InstitutionId { get; set; }

//            /// <summary>The date this was last updated.</summary>
//            [JsonProperty("date_last_updated")]
//            public DateTime DateLastUpdated { get; set; }

//            /// <summary>The accounts.</summary>
//            [JsonProperty("accounts")]
//            public Account[] Accounts { get; set; }

//            /// <summary>The model for account data.</summary>
//            public class Account
//            {
//                /// <summary>The account identifier.</summary>
//                [JsonProperty("account_id")]
//                public string AccountId { get; set; }

//                /// <summary>The last 4 digits of the account number (may not be unique).</summary>
//                [JsonProperty("mask")]
//                public string Mask { get; set; }

//                /// <summary>The name.</summary>
//                [JsonProperty("name")]
//                public string Name { get; set; }

//                /// <summary>The official name.</summary>
//                [JsonProperty("official_name")]
//                public string OfficialName { get; set; }

//                /// <summary>The type.</summary>
//                [JsonProperty("type")]
//                public string Type { get; set; }

//                /// <summary>The sub-type.</summary>
//                [JsonProperty("subtype")]
//                public string SubType { get; set; }

//                /// <summary>Thw owners.</summary>
//                [JsonProperty("owners")]
//                public Owner[] Owners { get; set; }

//                /// <summary>The balances.</summary>
//                [JsonProperty("balances")]
//                public Balance[] Balances { get; set; }

//                /// <summary>The historical balances.</summary>
//                [JsonProperty("historical_balances")]
//                public HistoricalBalance[] HistoricalBalances { get; set; }

//                /// <summary>The transactions.</summary>
//                [JsonProperty("transactions")]
//                public Transaction[] Transactions { get; set; }

//                /// <summary>The number of days available.</summary>
//                [JsonProperty("days_available")]
//                public int DaysAvailable { get; set; }

//                /// <summary>The model for account owner data.</summary>
//                public class Owner
//                {
//                    /// <summary>All associated names.</summary>
//                    [JsonProperty("names")]
//                    public string Names { get; set; }

//                    /// <summary>Phone numbers.</summary>
//                    [JsonProperty("phone_nmubers")]
//                    public PhoneNumber[] PhoneNumbers { get; set; }

//                    /// <summary>Email addresses.</summary>
//                    [JsonProperty("email_addresses")]
//                    public string[] Emails { get; set; }

//                    /// <summary>A list of addresses.</summary>
//                    [JsonProperty("addresses")]
//                    public Address[] Addresses { get; set; }

//                    public class PhoneNumber
//                    {
//                        /// <summary>The phone number.</summary>
//                        [JsonProperty("data")]
//                        public string Data { get; set; }

//                        /// <summary>True if this is the primary number on the account.</summary>
//                        [JsonProperty("primary")]
//                        public bool Primary { get; set; }

//                        /// <summary>The type of phone (e.g. "mobile").</summary>
//                        [JsonProperty("type")]
//                        public string Type { get; set; }
//                    }

//                    public class Address
//                    {
//                        /// <summary>True if this is the primary address on the account.</summary>
//                        [JsonProperty("primary")]
//                        public bool Primary { get; set; }

//                        /// <summary>The actual address data.</summary>
//                        [JsonProperty("data")]
//                        public AddressData Data { get; set; }

//                        public class AddressData
//                        {
//                            [JsonProperty("city")]
//                            public string City { get; set; }

//                            [JsonProperty("region")]
//                            public string Region { get; set; }

//                            [JsonProperty("street")]
//                            public string Street { get; set; }

//                            [JsonProperty("postal_code")]
//                            public string PostalCode { get; set; }

//                            [JsonProperty("country")]
//                            public string Country { get; set; }
//                        }
//                    }
//                }

//                public class Balance
//                {
//                    [JsonProperty("available")]
//                    public decimal? Available { get; set; }

//                    [JsonProperty("current")]
//                    public decimal Current { get; set; }

//                    [JsonProperty("iso_country_code")]
//                    public string IsoCountryCode { get; set; }

//                    [JsonProperty("unofficial_country_code")]
//                    public string UnofficialCountryCode { get; set; }
//                }

//                public class HistoricalBalance
//                {
//                    [JsonProperty("date")]
//                    public DateTime Date { get; set; }

//                    [JsonProperty("current")]
//                    public decimal Current { get; set; }

//                    [JsonProperty("iso_currency_code")]
//                    public string IsoCurrencyCode { get; set; }

//                    [JsonProperty("unofficial_currency_code")]
//                    public string UnofficialCurrencyCode { get; set; }
//                }

//                public class Transaction
//                {
//                    [JsonProperty("account_id")]
//                    public string AccountId { get; set; }

//                    [JsonProperty("transaction_id")]
//                    public string TransactionId { get; set; }

//                    [JsonProperty("date")]
//                    public DateTime Date { get; set; }

//                    [JsonProperty("original_description")]
//                    public string OriginalDescription { get; set; }

//                    [JsonProperty("pending")]
//                    public bool Pending { get; set; }

//                    /// <summary>Settled dollar(? according to docs) value, so positive is out-flowing, and negative is in-flowing money.</summary>
//                    [JsonProperty("amount")]
//                    public decimal Amount { get; set; }

//                    [JsonProperty("iso_currency_code")]
//                    public string IsoCurrencyCode { get; set; }

//                    [JsonProperty("unofficial_currency_code")]
//                    public string UnofficialCurrencyCode { get; set; }

//                    [JsonProperty("account_owner")]
//                    public string AccountOwner { get; set; }

//                    /// <summary>Hierarchical array of categories, only appears in an Asset Report with insights.</summary>
//                    [JsonProperty("category")]
//                    public string Category { get; set; }

//                    /// <summary>The ID of the category to which this transaction belongs. See Categories. This field only appears in an Asset Report with Insights.</summary>
//                    [JsonProperty("category_id")]
//                    public string CategoryId { get; set; }

//                    [JsonProperty("date_transacted")]
//                    public string DateTransacted { get; set; }

//                    [JsonProperty("location")]
//                    public TransactionLocation Location { get; set; }

//                    public class TransactionLocation
//                    {
//                        [JsonProperty("address")]
//                        public string Address { get; set; }

//                        [JsonProperty("city")]
//                        public string City { get; set; }

//                        [JsonProperty("region")]
//                        public string Region { get; set; }

//                        [JsonProperty("postal_code")]
//                        public string PostalCode { get; set; }

//                        [JsonProperty("country")]
//                        public string Country { get; set; }

//                        [JsonProperty("lat")]
//                        public decimal? Lat { get; set; }

//                        [JsonProperty("lng")]
//                        public decimal? Lng { get; set; }
//                    }

//                    [JsonProperty("name")]
//                    public string Name { get; set; }

//                    [JsonProperty("payment_meta")]
//                    public PaymentMetadata PaymentMeta { get; set; }

//                    [JsonProperty("pending_transaction_id")]
//                    public string PendingTransactionId { get; set; }

//                    /// <summary>One of "digital" (online transactions), "place" (physical store transactions), "special" (banking transactions such as fees or deposits), "unresolved" (not fitting within other 3 categories).
//                    /// NB: Only appears in Asset Reports with Insights</summary>
//                    [JsonProperty("transaction_type")]
//                    public string TransactionType { get; set; }

//                    public class PaymentMetadata
//                    {
//                        [JsonProperty("reference_number")]
//                        public string ReferenceNumber { get; set; }

//                        [JsonProperty("ppd_id")]
//                        public string PpdId { get; set; }

//                        [JsonProperty("payee")]
//                        public string Payee { get; set; }
//                    }
//                }
//            }
//        }
//    }
//}
