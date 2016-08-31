using HockeyAppAPIWeb.Lib.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;

namespace HockeyAppAPIWeb
{
    public class SQLiteHelper
    {
        private static SQLiteConnection GetConnection(string path)
        {
            string dbPath = $"Data Source={path};";
            return new SQLiteConnection(dbPath);
        }

        public static bool FeedReasionToDB(CrashGroupData groupData, string path)
        {
            try
            {
                using (SQLiteConnection connect = GetConnection(path))
                {
                    connect.Open();

                    SQLiteCommand sqlCmd = new SQLiteCommand("INSERT INTO Reason VALUES (@id, @app_id, @crash_reason_id, @created_at, @updated_at, " +
                                                             "@oem, @model, @os_version, @jail_break, @contact_string, @user_string, @has_log, @has_description, @app_version_id, " +
                                                             "@bundle_version, @bundle_short_version);");
                    sqlCmd.Connection = connect;

                    sqlCmd.Parameters.Add("@id", System.Data.DbType.Int64);
                    sqlCmd.Parameters.Add("@app_id", System.Data.DbType.Int32);
                    sqlCmd.Parameters.Add("@crash_reason_id", System.Data.DbType.Int32);
                    sqlCmd.Parameters.Add("@created_at", System.Data.DbType.DateTime);
                    sqlCmd.Parameters.Add("@updated_at", System.Data.DbType.DateTime);
                    sqlCmd.Parameters.Add("@oem", System.Data.DbType.String);
                    sqlCmd.Parameters.Add("@model", System.Data.DbType.String);
                    sqlCmd.Parameters.Add("@os_version", System.Data.DbType.String);
                    sqlCmd.Parameters.Add("@jail_break", System.Data.DbType.Boolean);
                    sqlCmd.Parameters.Add("@contact_string", System.Data.DbType.String);
                    sqlCmd.Parameters.Add("@user_string", System.Data.DbType.String);
                    sqlCmd.Parameters.Add("@has_log", System.Data.DbType.Boolean);
                    sqlCmd.Parameters.Add("@has_description", System.Data.DbType.Boolean);
                    sqlCmd.Parameters.Add("@app_version_id", System.Data.DbType.Int32);
                    sqlCmd.Parameters.Add("@bundle_version", System.Data.DbType.String);
                    sqlCmd.Parameters.Add("@bundle_short_version", System.Data.DbType.String);

                    foreach (var item in groupData.crashes)
                    {
                        sqlCmd.Parameters["@id"].Value = item.id;
                        sqlCmd.Parameters["@app_id"].Value = item.app_id;
                        sqlCmd.Parameters["@crash_reason_id"].Value = item.crash_reason_id;
                        sqlCmd.Parameters["@created_at"].Value = item.created_at;
                        sqlCmd.Parameters["@updated_at"].Value = item.updated_at;
                        sqlCmd.Parameters["@oem"].Value = item.oem;
                        sqlCmd.Parameters["@model"].Value = item.model;
                        sqlCmd.Parameters["@os_version"].Value = item.os_version;
                        sqlCmd.Parameters["@jail_break"].Value = item.jail_break;
                        sqlCmd.Parameters["@contact_string"].Value = item.contact_string;
                        sqlCmd.Parameters["@user_string"].Value = item.user_string;
                        sqlCmd.Parameters["@has_log"].Value = item.has_log;
                        sqlCmd.Parameters["@has_description"].Value = item.has_description;
                        sqlCmd.Parameters["@app_version_id"].Value = item.app_version_id;
                        sqlCmd.Parameters["@bundle_version"].Value = item.bundle_version;
                        sqlCmd.Parameters["@bundle_short_version"].Value = item.bundle_short_version;
                        int res = sqlCmd.ExecuteNonQuery();
                    }

                    sqlCmd.Dispose();
                    sqlCmd = null;

                    connect.Close();
                    connect.Dispose();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false; 
            }
        }

        //internal static RadioDataCollection ReadSQLite(string path)
        //{
        //    RadioDataCollection collection = new RadioDataCollection();

        //    try
        //    {
        //        using (SQLiteConnection connect = GetConnection(path))
        //        {
        //            connect.Open();

        //            SQLiteCommand sqlCmd = new SQLiteCommand("SELECT title, subtitle, avator, tag, id, seq, fm FROM radios ORDER BY title, sno");
        //            sqlCmd.Connection = connect;

        //            SQLiteDataReader reader = sqlCmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                collection.RadioList.Add(new RadioData
        //                {
        //                    Title = reader["title"].ToString(),
        //                    SubTitle = reader["subtitle"].ToString(),
        //                    Avator = reader["avator"].ToString(),
        //                    Tag = reader["tag"].ToString(),
        //                    Id = reader["id"].ToString(),
        //                    FM = reader["fm"].ToString(),
        //                    Seq = int.Parse(reader["seq"].ToString())
        //                });
        //            }

        //            reader.Close();
        //            reader = null;

        //            sqlCmd.Dispose();
        //            sqlCmd = null;

        //            connect.Close();
        //            connect.Dispose();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = ex.Message;
        //    }

        //    return collection;
        //}

        //public static string FeedChannelDataToSQLite(string path, ChannelDataCollection dataSource)
        //{
        //    List<ChannelData> notSupport = new List<ChannelData>();
        //    string result = string.Empty;
        //    try
        //    {
        //        using (SQLiteConnection connect = GetConnection(path))
        //        {
        //            connect.Open();

        //            SQLiteCommand sqlCmd = new SQLiteCommand("UPDATE radios SET id = @id WHERE title = @title;");
        //            sqlCmd.Connection = connect;

        //            sqlCmd.Parameters.Add("@id", System.Data.DbType.String);
        //            sqlCmd.Parameters.Add("@title", System.Data.DbType.String);

        //            foreach (var channel in dataSource.List)
        //            {
        //                if (!string.IsNullOrEmpty(channel.ChannelTitle))
        //                {
        //                    sqlCmd.Parameters["@id"].Value = channel.ChannelId;
        //                    sqlCmd.Parameters["@title"].Value = channel.ChannelTitle;

        //                    int res = sqlCmd.ExecuteNonQuery();
        //                    if (res == 0)
        //                    {
        //                        notSupport.Add(channel);
        //                    }
        //                    Debug.WriteLine($"FeedChannelDataToSQLite | UPDATE | {channel.ChannelTitle}, {channel.ChannelId}");
        //                }
        //            }

        //            if (notSupport.Count > 0)
        //            {
        //                sqlCmd.CommandText = "INSERT INTO radios(title, id) VALUES (@title, @id);";
        //                foreach (var channel in notSupport)
        //                {
        //                    if (!string.IsNullOrEmpty(channel.ChannelTitle))
        //                    {
        //                        sqlCmd.Parameters["@id"].Value = channel.ChannelId;
        //                        sqlCmd.Parameters["@title"].Value = channel.ChannelTitle;

        //                        int res = sqlCmd.ExecuteNonQuery();
        //                        Debug.WriteLine($"FeedChannelDataToSQLite | INSERT | {channel.ChannelTitle}, {channel.ChannelId}");
        //                    }
        //                }
        //            }

        //            sqlCmd.Dispose();
        //            sqlCmd = null;

        //            connect.Close();
        //            connect.Dispose();
        //        }

        //        result = "OK";
        //    }
        //    catch (Exception ex)
        //    {
        //        result = ex.Message;
        //    }

        //    return result;
        //}
    }
}