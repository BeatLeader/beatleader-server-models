using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models
{
    public class EventRanking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EndDate { get; set; }
        public int PlaylistId { get; set; }
        public string Image { get; set; }

        [JsonIgnore]
        public ICollection<Leaderboard> Leaderboards { get; set; }
        [JsonIgnore]
        public ICollection<EventPlayer> Players { get; set; }
    }
}
