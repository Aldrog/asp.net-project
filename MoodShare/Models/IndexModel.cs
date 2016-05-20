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
        }
        public List<Mood> moods;

        public IndexModel ()
        {
            moods = new List<Mood> ();
            IDbConnection conn = new SqliteConnection ("Data Source=moodbase.db");
            conn.Open ();
            IDbCommand cmd = conn.CreateCommand ();
            cmd.CommandText = "SELECT id, name FROM moods";
            IDataReader reader = cmd.ExecuteReader ();
            while (reader.Read ()) {
                int id = reader.GetInt32 (0);
                string name = reader.GetString (1);
                moods.Add (new Mood { id = id, name = name });
            }
        }
    }
}

