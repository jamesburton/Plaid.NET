using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acklann.Plaid.Entity
{
    /// <summary>The asset report model.</summary>
    public class AssetReport
    {
        /// <summary>The asset-report identifier.</summary>
        [JsonProperty("asset_report_id")]
        public string AssetReportId { get; set; }

        /// <summary>The client's report identifier (optional).</summary>
        [JsonProperty("client_report_id")]
        public string ClientReportId { get; set; }

        /// <summary>The date this report was generated.</summary>
        [JsonProperty("date_generated")]
        public DateTime DateGenerated { get; set; }

        /// <summary>The number of days requested.</summary>
        [JsonProperty("days_requested")]
        public int DaysRequested { get; set; }

        /// <summary>The user data assigned for this report.</summary>
        [JsonProperty("user")]
        public User User { get; set; }

        /// <summary>The report items.</summary>
        [JsonProperty("items")]
        public ReportItem[] Items { get; set; }
    }
}
