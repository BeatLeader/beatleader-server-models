namespace BeatLeader.Models;

public class Leaderboard {
    public required string Id { get; set; }
    public string? SongId { get; set; }
    public required Song Song { get; set; }
    public required DifficultyDescription Difficulty { get; set; }
    public required ICollection<Score> Scores { get; set; }
    public required ICollection<ScoreContextExtension> ContextExtensions { get; set; }
    public RankQualification? Qualification { get; set; }
    public RankUpdate? Reweight { get; set; }

    public long Timestamp { get; set; }

    public LeaderboardGroup? LeaderboardGroup { get; set; }
    public ICollection<LeaderboardChange>? Changes { get; set; }
    public ICollection<PlayerLeaderboardStats>? PlayerStats { get; set; }

    public ICollection<EventRanking>? Events { get; set; }
    public int Plays { get; set; }
    public int PlayCount { get; set; }

    public int PositiveVotes { get; set; }
    public int StarVotes { get; set; }
    public int NegativeVotes { get; set; }
    public float VoteStars { get; set; }

    public int? ClanId { get; set; }
    public Clan? Clan { get; set; }

    public ICollection<ClanRanking>? ClanRanking { get; set; }
    public bool ClanRankingContested { get; set; }
}

public class LeaderboardGroup {
    public int Id { get; set; }
    public required ICollection<Leaderboard> Leaderboards { get; set; }
}