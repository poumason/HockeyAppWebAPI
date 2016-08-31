using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HockeyAppAPIWeb.Lib.Data
{
    public class CrashReasonsData
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("app_id")]
        public int app_id { get; set; }

        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }

        [JsonProperty("updated_at")]
        public DateTime updated_at { get; set; }

        [JsonProperty("status")]
        public int status { get; set; }

        [JsonProperty("reason")]
        public string reason { get; set; }

        [JsonProperty("last_crash_at")]
        public DateTime last_crash_at { get; set; }

        [JsonProperty("exception_type")]
        public object exception_type { get; set; }

        [JsonProperty("_fixed")]
        public bool _fixed { get; set; }

        [JsonProperty("app_version_id")]
        public int app_version_id { get; set; }

        [JsonProperty("bundle_version")]
        public string bundle_version { get; set; }

        [JsonProperty("bundle_short_version")]
        public object bundle_short_version { get; set; }

        [JsonProperty("number_of_crashes")]
        public int number_of_crashes { get; set; }

        [JsonProperty("grouping_hash")]
        public string grouping_hash { get; set; }

        [JsonProperty("grouping_type")]
        public int grouping_type { get; set; }

        [JsonProperty("method")]
        public string method { get; set; }

        [JsonProperty("file")]
        public string file { get; set; }

        [JsonProperty("_class")]
        public string _class { get; set; }

        [JsonProperty("line")]
        public string line { get; set; }

        [JsonProperty("pattern")]
        public string pattern { get; set; }
    }
}