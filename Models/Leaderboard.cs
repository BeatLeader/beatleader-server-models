namespace BeatLeader.Models;

public class Leaderboard {
    public string Id { get; set; } = null!;
    public string? SongId { get; set; }
    public Song Song { get; set; } = null!;
    public DifficultyDescription Difficulty { get; set; } = null!;
    public ICollection<Score> Scores { get; set; } = null!;
    public ICollection<ScoreContextExtension> ContextExtensions { get; set; } = null!;
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
    public ICollection<Leaderboard> Leaderboards { get; set; } = null!;
}