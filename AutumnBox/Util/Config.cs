﻿using AutumnBox.Debug;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutumnBox.Util
{
    internal static class Config
    {
        internal static ConfigSql config = new ConfigSql();
        internal static bool isShowSideloadTur
        {
            set { config.Set("boolValues", "isShowSideloadTur", value); }
            get { return Convert.ToBoolean(config.Read("boolValues", "isShowSideloadTur")); }
        }
        internal static string language
        {
            set { config.Set("stringValues", "language", value); }
            get { return config.Read("stringValues", "language").ToString(); }
        }
    }

    internal class ConfigSql
    {
        private const string SQL_PATH = "atb.data";
        private SQLiteConnection dbConnection;
        private const string TAG = "Config";
        public ConfigSql()
        {
            Console.WriteLine("Shit");
            try
            {
                dbConnection = new SQLiteConnection($"Data Source={SQL_PATH};Version=3;");
                dbConnection.Open();
            }
            catch (Exception e)
            {
                Log.d(TAG, "发生错误,初始化数据库" + e.Message);
                InitSql();
                
            }
        }
        private void InitSql()
        {
            SQLiteConnection.CreateFile(SQL_PATH);
            dbConnection = new SQLiteConnection($"Data Source={SQL_PATH};Version=3;");
            dbConnection.Open();
        }
        private void InitTable()
        {
            string[] sqls = {
                "create table boolValues (key char(20), value boolean) ",
                "create table intValues (key char(20), value int) ",
                "create table stringValues (key char(20), value char(20)) ",
            };
            foreach (string sql in sqls) {
                ExecuteSqlCommand(sql);
            }
        }
        public object Read(string table, string key)
        {
            string sql = $"select * from {table} where key='{key}'";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader["key"];
        }
        private void ExecuteSqlCommand(string c)
        {
            SQLiteCommand command = new SQLiteCommand(c,dbConnection);
            command.ExecuteNonQuery();
        }
        public void Set(string table, string key, int value)
        {

        }
        public void Set(string table, string key, bool value)
        {

        }
        public void Set(string table, string key, string value)
        {

        }
    }
}
