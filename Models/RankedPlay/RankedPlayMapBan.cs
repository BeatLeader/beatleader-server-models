using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models {
    [Index(nameof(SeasonId), nameof(LeaderboardId), IsUnique = true)]
    public class RankedPlayMapBan {
        public int Id { get; set; }
        public int? SeasonId { get; set; }
        [JsonIgnore]
        public RankedPlaySeason? Season { get; set; }
        public string? LeaderboardId { get; set; }
        [JsonIgnore]
        public Leaderboard? Leaderboard { get; set; }
        public string? Reason { get; set; }
        public int BannedAt { get; set; }
    }
}
