using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models {
    public class Leaderboard : StringTrackedEntity {
        public string Id { get; set; }
        public string? SongId { get; set; }
        public Song Song { get; set; }
        public DifficultyDescription Difficulty { get; set; }
        [JsonIgnore]
        public ICollection<Score> Scores { get; set; }
        [JsonIgnore]
        public ICollection<FailedScore> FailedScores { get; set; }
        [JsonIgnore]
        public ICollection<ScoreContextExtension> ContextExtensions { get; set; }
        public RankQualification? Qualification { get; set; }
        public RankUpdate? Reweight { get; set; }
        [JsonIgnore]
        public ICollection<FeaturedPlaylist>? FeaturedPlaylists { get; set; }

        public long Timestamp { get; set; }

        [JsonIgnore]
        public LeaderboardGroup? LeaderboardGroup { get; set; }
        public ICollection<LeaderboardChange>? Changes { get; set; }

        public ICollection<EventRanking>? Events { get; set; }
        public int Plays { get; set; }
        public int PlayCount { get; set; }
        public int LastScoreTime { get; set; }

        public int TodayPlays { get; set; }
        public int ThisWeekPlays { get; set; }

        public int PositiveVotes { get; set; }
        public int StarVotes { get; set; }
        public int NegativeVotes { get; set; }
        public float VoteStars { get; set; }

        public int FansCount { get; set; }

        public int? ClanId { get; set; }
        [JsonIgnore]
        public Clan? Clan { get; set; }
        public int? CapturedTime { get; set; }

        [JsonIgnore]
        public ICollection<ClanRanking>? ClanRanking { get; set; }
        public bool ClanRankingContested { get; set; }

        [JsonIgnore]
        public ICollection<PredictedScore> PredictedScores { get; set; }
        [JsonIgnore]
        public ICollection<FavoriteMap> FavoriteMaps { get; set; }
    }

    public class LeaderboardGroup {
        public int Id { get; set; }
        public ICollection<Leaderboard> Leaderboards { get; set; }
    }
}
