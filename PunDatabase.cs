using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace The_Oracle
{
    public enum database_target
    {
        PROD = 0,
        DEV = 1
    }

    public class PunDatabase
    {
        /*
         * Fetch all topics
         * Fetch by topic
         * Fetch all
         * Edit line
         * Fetch by quality range
         * Fetch by any text
         */

        private SqliteConnection Connection;

        public void Open(database_target db_target)
        {
            if (Connection == null || Connection.State == System.Data.ConnectionState.Closed)
            {
                Connection = new SqliteConnection(@"Data Source=C:\Users\nmbro\Documents\Pun Generator\pubsdb-dev.db");
                Connection.Open();
            }
        }

        public void Close()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }

        public string[] FetchAllTopics()
        {
            throw new NotImplementedException();
        }

        public PunEntry[] FechByTopic(string[] topics, bool include_used = false)
        {
            throw new NotImplementedException();
        }

        public void MarkUsed(PunEntry entry)
        {

        }

        public PunEntry[] FetchByQuality(int min, int max, bool include_used = false, bool include_topical = false)
        {
            SqliteCommand cmd = new SqliteCommand("SELECT * FROM PUNS WHERE IS_TOPICAL=0 AND USED=0", Connection);
            using SqliteDataReader rdr = cmd.ExecuteReader();

            List<PunEntry> entries = new List<PunEntry>();
            while (rdr.Read())
            {
                PunEntry entry = new PunEntry();
                entry.UID = rdr.GetInt32(0);
                entry.Text = rdr.GetString(1);
                entry.Quality = rdr.GetInt32(2);
                entry.Tags = rdr.IsDBNull(3) ? "" : rdr.GetString(3);
                entry.IsTopical = rdr.GetInt32(4) == 0 ? false : true;
                entry.Used = rdr.GetInt32(5) == 0 ? false : true;

                entries.Add(entry);
            }

            return entries.ToArray();

        }
    }
}
