using Microsoft.EntityFrameworkCore;
using ReplayDecoder;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models {

    [Index(nameof(PlayerId), nameof(LeaderboardId), nameof(Context), IsUnique = true)]
    public class ScoreContextExtension : IScore
    {
        public int Id { get; set; }
        public string PlayerId { get; set; }
        public Player Player { get; set; }
        public string LeaderboardId { get; set; }
        public Leaderboard Leaderboard { get; set; }
        public float Weight { get; set; }
        public int Rank { get; set; }
        public int BaseScore { get; set; }
        public int ModifiedScore { get; set; }
        public float Accuracy { get; set; }
        public float Pp { get; set; }
        public float PassPP { get; set; }
        public float AccPP { get; set; }
        public float TechPP { get; set; }
        public float BonusPp { get; set; }
        public string? Modifiers { get; set; }
        public float ModifiedStars { get; set; }
        public int Timepost { get; set; }
        public int Priority { get; set; }

        public int? ScoreId { get; set; }
        [ForeignKey("ScoreId")]
        public Score? ScoreInstance { get; set; }
        public bool Qualification { get; set; }
        public bool Banned { get; set; }

        public LeaderboardContexts Context { get; set; }
        public ScoreImprovement? ScoreImprovement { get; set; }
        [NotMapped]
        [JsonIgnore]
        public string? Replay { get => ScoreInstance != null ? ScoreInstance.Replay : null; set => ScoreInstance.Replay = value; }
        [NotMapped]
        [JsonIgnore]
        public string Platform { get => ScoreInstance != null ? ScoreInstance.Platform : ""; set => ScoreInstance.Platform = value; }
        [NotMapped]
        [JsonIgnore]
        public int MaxCombo { get => ScoreInstance != null ? ScoreInstance.MaxCombo : 0; set => ScoreInstance.MaxCombo = value; }
        [NotMapped]
        [JsonIgnore]
        public int BadCuts { get => ScoreInstance != null ? ScoreInstance.BadCuts : 0; set => ScoreInstance.BadCuts = value; }
        [NotMapped]
        [JsonIgnore]
        public int MissedNotes { get => ScoreInstance != null ? ScoreInstance.MissedNotes : 0; set => ScoreInstance.MissedNotes = value; }
        [NotMapped]
        [JsonIgnore]
        public int BombCuts { get => ScoreInstance != null ? ScoreInstance.BombCuts : 0; set => ScoreInstance.BombCuts = value; }
        [NotMapped]
        [JsonIgnore]
        public int WallsHit { get => ScoreInstance != null ? ScoreInstance.WallsHit : 0; set => ScoreInstance.WallsHit = value; }
        [NotMapped]
        [JsonIgnore]
        public int Pauses { get => ScoreInstance != null ? ScoreInstance.Pauses : 0; set => ScoreInstance.Pauses = value; }
        [NotMapped]
        [JsonIgnore]
        public bool FullCombo { get => ScoreInstance != null ? ScoreInstance.FullCombo : false; set => ScoreInstance.FullCombo = value; }
        [NotMapped]
        [JsonIgnore]
        public HMD Hmd { get => ScoreInstance != null ? ScoreInstance.Hmd : HMD.unknown; set => ScoreInstance.Hmd = value; }
        [NotMapped]
        [JsonIgnore]
        public ControllerEnum Controller { get => ScoreInstance != null ? ScoreInstance.Controller : ControllerEnum.unknown; set => ScoreInstance.Controller = value; }
        [NotMapped]
        [JsonIgnore]
        public float AccRight { get => ScoreInstance != null ? ScoreInstance.AccRight : 0; set => ScoreInstance.AccRight = value; }
        [NotMapped]
        [JsonIgnore]
        public float AccLeft { get => ScoreInstance != null ? ScoreInstance.AccLeft : 0; set => ScoreInstance.AccLeft = value; }
        [NotMapped]
        [JsonIgnore]
        public int? MaxStreak { get => ScoreInstance != null ? ScoreInstance.MaxStreak : 0; set => ScoreInstance.MaxStreak = value; }
        [NotMapped]
        [JsonIgnore]
        public float FcAccuracy { get => ScoreInstance != null ? ScoreInstance.FcAccuracy : 0; set => ScoreInstance.FcAccuracy = value; }
        [NotMapped]
        [JsonIgnore]
        public float FcPp { get => ScoreInstance != null ? ScoreInstance.FcPp : 0; set => ScoreInstance.FcPp = value; }
        [NotMapped]
        [JsonIgnore]
        public int PlayCount { get => ScoreInstance != null ? ScoreInstance.PlayCount : 0; set => ScoreInstance.PlayCount = value; }
        [NotMapped]
        [JsonIgnore]
        public int LastTryTime { get => ScoreInstance != null ? ScoreInstance.LastTryTime : 0; set => ScoreInstance.LastTryTime = value; }
        [NotMapped]
        [JsonIgnore]
        public float LeftTiming { get => ScoreInstance != null ? ScoreInstance.LeftTiming : 0; set => ScoreInstance.LeftTiming = value; }
        [NotMapped]
        [JsonIgnore]
        public float RightTiming { get => ScoreInstance != null ? ScoreInstance.RightTiming : 0; set => ScoreInstance.RightTiming = value; }
        [NotMapped]
        [JsonIgnore]
        public bool Suspicious { get => ScoreInstance != null ? ScoreInstance.Suspicious : false; set => ScoreInstance.Suspicious = value; }
        [NotMapped]
        [JsonIgnore]
        public bool IgnoreForStats { get => ScoreInstance != null ? ScoreInstance.IgnoreForStats : false; set => ScoreInstance.IgnoreForStats = value; }
        [NotMapped]
        [JsonIgnore]
        public int AuthorizedReplayWatched { get => ScoreInstance != null ? ScoreInstance.AuthorizedReplayWatched : 0; set => ScoreInstance.AuthorizedReplayWatched = value; }
        [NotMapped]
        [JsonIgnore]
        public int AnonimusReplayWatched { get => ScoreInstance != null ? ScoreInstance.AnonimusReplayWatched : 0; set => ScoreInstance.AnonimusReplayWatched = value; }
        [NotMapped]
        [JsonIgnore]
        public ReplayOffsets? ReplayOffsets { get => ScoreInstance != null ? ScoreInstance.ReplayOffsets : null; set => ScoreInstance.ReplayOffsets = value; }
        [NotMapped]
        [JsonIgnore]
        public RankVoting? RankVoting { get => ScoreInstance != null ? ScoreInstance.RankVoting : null; set => ScoreInstance.RankVoting = value; }
        [NotMapped]
        [JsonIgnore]
        public ScoreMetadata? Metadata { get => ScoreInstance != null ? ScoreInstance.Metadata : null; set => ScoreInstance.Metadata = value; }
        [NotMapped]
        [JsonIgnore]
        public string Time { get => ScoreInstance != null ? ScoreInstance.Timepost.ToString() : Timepost.ToString(); set => Timepost = 0; }
        [NotMapped]
        [JsonIgnore]
        public string? Country { get => ScoreInstance != null ? ScoreInstance.Country : null; set => ScoreInstance.Country = value; }
    }
}
