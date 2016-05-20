using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

        public struct Track {
            public int number;
            public string name;
            public string performer;
            public string url;
        }

        public List<Track> trackList(int id) {
            List<Track> tl = new List<Track> ();
            var files = Directory.EnumerateFiles ("Data/" + id + "/music/");
            foreach (var f in files) {
                // File name is supposed to look like "N Performer - Song name.mp3"
                //TODO: get track info from tags
                string fname = f.Remove (f.LastIndexOf ('.')).Substring(f.LastIndexOf('/') + 1);
                int n;
                int.TryParse(fname.Remove (fname.IndexOf (' ')), out n);
                fname = fname.Substring (fname.IndexOf (' ') + 1);
                string perf = fname.Remove (fname.IndexOf (" - "));
                fname = fname.Substring (fname.IndexOf (" - ") + 3);
                tl.Add (new Track () {
                    number = n,
                    name = fname,
                    performer = perf,
                    url = f
                });
            }

            return tl;
        }
    }
}

