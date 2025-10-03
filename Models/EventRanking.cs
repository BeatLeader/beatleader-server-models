using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models
{
    public enum EventRankingType {
        Playlist = 0,
        MapOfTheDay = 1
    }

    public class EventRanking : TrackedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EndDate { get; set; }
        public int PlaylistId { get; set; }
        public string Image { get; set; }
        public string? Description { get; set; }
        public string? AnimatedImage { get; set; }

        public string MainColor { get; set; } = "";
        public string SecondaryColor { get; set; } = "";

        public string? PageAlias { get; set; }

        public EventRankingType EventType { get; set; }

        [JsonIgnore]
        public ICollection<Leaderboard> Leaderboards { get; set; }
        [JsonIgnore]
        public ICollection<EventPlayer> Players { get; set; }
        [JsonIgnore]
        public ICollection<MapOfTheDay> MapOfTheDays { get; set; }
        [JsonIgnore]
        public FeaturedPlaylist? FeaturedPlaylist { get; set; }
    }

    public class ScheduledEventMap {
        public int Id { get; set; }
        public string SongId { get; set; }
        public int EventId { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public string? VideoUrl { get; set; }
    }
}
