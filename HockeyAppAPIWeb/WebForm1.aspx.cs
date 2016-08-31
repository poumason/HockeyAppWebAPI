using HockeyAppAPIWeb.Lib.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HockeyAppAPIWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //protected void GetApp_Click(object sender, EventArgs e)
        //{
        //    string key = ConfigurationManager.AppSettings.Get("HockeyAppKey");
        //    string url = "https://rink.hockeyapp.net/api/2/apps";

        //    using (WebClient client = new WebClient())
        //    {
        //        client.Headers.Add("X-HockeyAppToken", key);
        //        lablLog.Text = client.DownloadString(url);
        //    }
        //}

        //protected void GetVersion_Click(object sender, EventArgs e)
        //{
        //    string appId = txtAppId.Text;
        //    string key = ConfigurationManager.AppSettings.Get("HockeyAppKey");
        //    string url = $"https://rink.hockeyapp.net/api/2/apps/{appId}/app_versions";

        //    using (WebClient client = new WebClient())
        //    {
        //        client.Headers.Add("X-HockeyAppToken", key);
        //        lablLog.Text = client.DownloadString(url);
        //    }
        //}

        //protected void WriteCrash_Click(object sender, EventArgs e)
        //{
        //    string appId = txtAppId.Text;
        //    string version = txtVersion.Text;
        //    string reasonId = txtResonId.Text;
        //    string key = ConfigurationManager.AppSettings.Get("HockeyAppKey");
        //    // get crash groups of the version
        //    //string url = $"https://rink.hockeyapp.net/api/2/apps/{appId}/app_versions/{version}/crash_reasons";
        //    string url = $"https://rink.hockeyapp.net/api/2/apps/{appId}/crash_reasons/{reasonId}";

        //    using (WebClient client = new WebClient())
        //    {
        //        client.Headers.Add("Content-Type", "application/json;charset=utf-8");
        //        client.Headers.Add("X-HockeyAppToken", key);
        //        lablLog.Text = client.DownloadString(url);
        //    }
        //}

        protected void OnDownloadDbFile_Click(object sender, EventArgs e)
        {
            string appId = txtAppId.Text;
            string version = txtVersion.Text;
            string reasonId = txtReasonId.Text;
            string url = $"https://rink.hockeyapp.net/api/2/apps/{appId}/crash_reasons/{reasonId}?page=1&per_page=100";

            var response = RequestHockeyApp(url);

            var crashGroupItem = JsonConvert.DeserializeObject<CrashGroupData>(response);

            for (int i = crashGroupItem.current_page+1; i <= crashGroupItem.total_pages; i++)
            {
                string newUrl = string.Format($"https://rink.hockeyapp.net/api/2/apps/{appId}/crash_reasons/{reasonId}?page={i}&per_page=100");
                string jsonResult = RequestHockeyApp(url);

                var groupItem = JsonConvert.DeserializeObject<CrashGroupData>(response);

                crashGroupItem.crashes.AddRange(groupItem.crashes);
            }
            
            string oldPath = Server.MapPath("./Assets/HockeyApp.db");
            string newPath = Server.MapPath($"./Assets/HockeyApp_{Guid.NewGuid().ToString()}.db");

            File.Copy(oldPath, newPath);

            var result = SQLiteHelper.FeedReasionToDB(crashGroupItem, newPath);

            if (result)
            {
                Response.WriteFile(newPath);
            }
        }

        private string RequestHockeyApp(string url)
        {
            string json = string.Empty;
            string key = ConfigurationManager.AppSettings.Get("HockeyAppKey");

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json;charset=utf-8");
                client.Headers.Add("X-HockeyAppToken", key);
                json = client.DownloadString(url);
            }

            return json;
        }

      

    }
}