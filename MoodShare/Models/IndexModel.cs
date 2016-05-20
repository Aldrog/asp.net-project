using System;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;

namespace MoodShare
{
    public class IndexModel
    {
        public struct Mood {
            public int id;
            public string name;
            public string author;
            public DateTime creationTime;
        }
        public List<Mood> moods;

        public IndexModel ()
        {
            moods = new List<Mood> ();
            IDbConnection conn = new SqliteConnection ("Data Source=Data/database.db");
            conn.Open ();
            IDbCommand cmd = conn.CreateCommand ();
            cmd.CommandText = "SELECT id, name, author, creationTime FROM moods";
            IDataReader reader = cmd.ExecuteReader ();
            while (reader.Read ()) {
                int id = reader.GetInt32 (0);
                string name = reader.GetString (1);
                string author = reader.GetString (2);
                DateTime creationTime = DateTime.FromFileTimeUtc(reader.GetInt64 (3));
                moods.Add (new Mood { id = id, name = name, author = author, creationTime = creationTime });
            }
        }
    }
}

