using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models {
    public class RankedPlaySeason {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public bool IsActive { get; set; }

        [JsonIgnore]
        public ICollection<RankedPlayProfile> Profiles { get; set; }
        [JsonIgnore]
        public ICollection<RankedPlayMatch> Matches { get; set; }
        [JsonIgnore]
        public ICollection<RankedPlayMapBan> MapBans { get; set; }
    }
}
