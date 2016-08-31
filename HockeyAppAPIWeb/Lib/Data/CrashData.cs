using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HockeyAppAPIWeb.Lib.Data
{
    public class CrashData
    {
        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("app_id")]
        public int app_id { get; set; }

        [JsonProperty("crash_reason_id")]
        public int crash_reason_id { get; set; }

        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }

        [JsonProperty("updated_at")]
        public DateTime updated_at { get; set; }

        [JsonProperty("oem")]
        public string oem { get; set; }

        [JsonProperty("model")]
        public string model { get; set; }

        [JsonProperty("os_version")]
        public string os_version { get; set; }

        [JsonProperty("jail_break")]
        public bool jail_break { get; set; }

        [JsonProperty("contact_string")]
        public string contact_string { get; set; }

        [JsonProperty("user_string")]
        public string user_string { get; set; }

        [JsonProperty("has_log")]
        public bool has_log { get; set; }

        [JsonProperty("has_description")]
        public bool has_description { get; set; }

        [JsonProperty("app_version_id")]
        public int app_version_id { get; set; }

        [JsonProperty("bundle_version")]
        public string bundle_version { get; set; }

        [JsonProperty("bundle_short_version")]
        public object bundle_short_version { get; set; }
    }
}