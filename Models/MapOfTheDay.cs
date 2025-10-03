namespace BeatLeader_Server.Models {
    public class MapOfTheDay {
        public int Id { get; set; }

        public string? SongId { get; set; }
        public Song? Song { get; set; }
        public ICollection<Leaderboard> Leaderboards { get; set; }
        public int Timestart { get; set; }
        public int Timeend { get; set; }

        public string? Description { get; set; }
        public ICollection<EventPlayer> Champions { get; set; }
        public EventRanking? EventRanking { get; set; }
    }

    public class MapOfTheDayPoints {
        public int Id { get; set; }
        public int Points { get; set; }
        public int Rank { get; set; }
        public MapOfTheDay MapOfTheDay { get; set; }
    }
}
