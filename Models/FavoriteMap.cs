namespace BeatLeader_Server.Models {

    [Flags]
    public enum FavoriteMapAspect
    {
        None = 0,
        Map = 1 << 1,
        Music = 1 << 2,
    }

    public class FavoriteMap {
        public int Id { get; set; }
        public int Timeset { get; set; }

        public string? LeaderboardId { get; set; }
        public Leaderboard? Leaderboard { get; set; }

        public string? PlayerId { get; set; }
        public Player? Player { get; set; }

        public int? RankVotingId { get; set; }
        public RankVoting? RankVoting { get; set; }

        public FavoriteMapAspect Aspect { get; set; }

        public string? Comment { get; set; }

    }
}
