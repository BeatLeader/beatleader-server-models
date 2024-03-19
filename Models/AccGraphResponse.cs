using Newtonsoft.Json;

namespace BeatLeader_Server.Models {

    public interface IGraphResponse {
        public string LeaderboardId { get; set; }
        public string Diff { get; set; }
        public string Mode { get; set; }
        public string Modifiers { get; set; }
        public string SongName { get; set; }
        public string Hash { get; set; }
        public string Mapper { get; set; }
        public int Timeset { get; set; }
        public float? Stars { get; set; }
        public ModifiersRating? ModifiersRating { get; set; }
        public ModifiersMap? ModifierValues { get; set; }
        public float? PassRating { get; set; }
        public float? AccRating { get; set; }
        public float? TechRating { get; set; }
    }
    public class GraphResponse : IGraphResponse {
        public string LeaderboardId { get; set; }
        public string Diff { get; set; }
        public string Mode { get; set; }
        public string Modifiers { get; set; }
        public string SongName { get; set; }
        public string Hash { get; set; }
        public string Mapper { get; set; }
        public int Timeset { get; set; }
        public float? Stars { get; set; }

        [JsonIgnore]
        public ModifiersRating? ModifiersRating { get; set; }
        [JsonIgnore]
        public ModifiersMap? ModifierValues { get; set; }
        [JsonIgnore]
        public float? PassRating { get; set; }
        [JsonIgnore]
        public float? AccRating { get; set; }
        [JsonIgnore]
        public float? TechRating { get; set; }
    }

    public class AccGraphResponse : GraphResponse {
        public float Acc { get; set; }
    }

    public class RankGraphResponse : GraphResponse {
        public float Weight { get; set; }
        public int Rank { get; set; }
        public int ScoreCount { get; set; }
        public float Ratio { get; set; }
    }

    public class WeightGraphResponse : GraphResponse {
        public float Weight { get; set; }
        public float Pp { get; set; }
    }
}
