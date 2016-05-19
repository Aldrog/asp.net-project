using System;
using System.Collections.Generic;

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
        }
    }
}

