using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace The_Oracle
{
    public class PunDatabase
    {
        private SqliteConnection Connection;

#if DEBUG
        string datasource = @"Data Source=..\..\..\PunDB\punsdb-dev.db";
#else
        string datasource = @"Data Source=..\..\..\PunDB\punsdb.db";
#endif

        private void Open()
        {
            if (Connection == null || Connection.State == System.Data.ConnectionState.Closed)
            {
                Connection = new SqliteConnection(datasource);
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

        public PunEntry[] Search(int min, int max, string[] tags, bool include_used = false)
        {            
            string qry = "SELECT * FROM PUNS ";

            // Add quality filter
            qry += "WHERE QUALITY BETWEEN " + min + " AND " + max + " ";

            // Add tag filter
            if (tags != null && tags.Length != 0)
            {
                for (int i = 0; i < tags.Count(); i++)
                {
                    if (i == 0)
                    {
                        qry += "AND ( ";
                    }
                    qry += "TAGS LIKE " + "'%" + tags[i] + "%' ";
                    if (i != tags.Count() - 1)
                    {
                        qry += "OR ";
                    }
                    else
                    {
                        qry += ")";
                    }
                }
            }
            else
            {
                // No tags, so exclude all tags
                qry += "AND IS_TOPICAL = 0 ";
            }

            qry += (include_used ? "" : " AND USED = 0");

            Open();
            SqliteCommand cmd = new SqliteCommand(qry, Connection);
            using SqliteDataReader rdr = cmd.ExecuteReader();
            return InflatePunEntryList(rdr);
        }

        public string[] FetchAllTags(bool include_used = false)
        {
            string qry = "SELECT TAGS FROM PUNS" + (include_used ? "" : " WHERE USED = 0");

            Open();

            SqliteCommand cmd = new SqliteCommand(qry, Connection);
            using SqliteDataReader rdr = cmd.ExecuteReader();

            List<string> allTags = new List<string>();

            while (rdr.Read())
            {
                string tags = rdr.IsDBNull(0) ? "" : rdr.GetString(0);
                if (tags != "")
                {
                    string[] splitTags = tags.Split(' ');
                    allTags.AddRange(splitTags);
                }
            }

            return allTags.Distinct().OrderBy(s => s).ToArray();
        }

        public PunEntry MarkUsed(PunEntry entry, bool used)
        {
            Open();
            SqliteCommand cmd = new SqliteCommand("UPDATE PUNS SET USED = " + (used?1:0) + " WHERE UID = " + entry.UID, Connection);
            cmd.ExecuteNonQuery();

            cmd = new SqliteCommand("SELECT * FROM PUNS WHERE UID = " + entry.UID, Connection);
            using SqliteDataReader rdr = cmd.ExecuteReader();

            return InflatePunEntryList(rdr)[0];
        }

        private PunEntry[] InflatePunEntryList( SqliteDataReader reader )
        {
            List<PunEntry> entries = new List<PunEntry>();
            while (reader.Read())
            {
                PunEntry entry = new PunEntry();
                entry.UID = reader.GetInt32(0);
                entry.Text = reader.GetString(1);
                entry.Quality = reader.GetInt32(2);
                entry.Tags = reader.IsDBNull(3) ? "" : reader.GetString(3);
                entry.IsTopical = reader.GetInt32(4) == 0 ? false : true;
                entry.Used = reader.GetInt32(5) == 0 ? false : true;

                entries.Add(entry);
            }

            return entries.ToArray();
        }
    }
}
