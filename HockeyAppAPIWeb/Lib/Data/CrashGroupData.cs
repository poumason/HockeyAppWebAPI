using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HockeyAppAPIWeb.Lib.Data
{
    public class CrashGroupData
    {
        [JsonProperty("crash_reason")]
        public CrashReasonsData crash_reason { get; set; }

        [JsonProperty("crashes")]
        public List<CrashData> crashes { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("current_page")]
        public int current_page { get; set; }

        [JsonProperty("per_page")]
        public int per_page { get; set; }

        [JsonProperty("total_entries")]
        public int total_entries { get; set; }

        [JsonProperty("total_pages")]
        public int total_pages { get; set; }
    }
}