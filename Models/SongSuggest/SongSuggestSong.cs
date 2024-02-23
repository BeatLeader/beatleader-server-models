﻿namespace BeatLeader_Server.Models.SongSuggest
{
    public class SongSuggestSong
    {
        public string ID { get; set; }
        public string name { get; set; }
        public string hash { get; set; }
        public string difficulty { get; set; }
        public string mode { get; set; }
        public float stars { get; set; }

        public float accRating { get; set; }
        public float passRating { get; set; }
        public float techRating { get; set; }
    }
}
