using Newtonsoft.Json;

namespace BeatLeader.Models.SongSuggest {
    public class Top10kScore {
        public String songID { get; set; }
        public float pp { get; set; }
        public int rank { get; set; }

        [JsonIgnore]
        public float accuracy { get; set; }

        [JsonIgnore]
        public int timepost { get; set; }

    }
}