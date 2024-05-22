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
        
        public int Timeset { get; set; }
        public int Timepost { get; set; }
        public int Priority { get; set; }

        public int? ScoreId { get; set; }
        public Score? Score { get; set; }
        public bool Qualification { get; set; }
        public bool Banned { get; set; }

        public LeaderboardContexts Context { get; set; }
        public ScoreImprovement? ScoreImprovement { get; set; }
        [NotMapped]
        [JsonIgnore]
        public string? Replay { get => Score != null ? Score.Replay : null; set => Score.Replay = value; }
        [NotMapped]
        [JsonIgnore]
        public string Platform { get => Score != null ? Score.Platform : ""; set => Score.Platform = value; }
        [NotMapped]
        [JsonIgnore]
        public int MaxCombo { get => Score != null ? Score.MaxCombo : 0; set => Score.MaxCombo = value; }
        [NotMapped]
        [JsonIgnore]
        public int BadCuts { get => Score != null ? Score.BadCuts : 0; set => Score.BadCuts = value; }
        [NotMapped]
        [JsonIgnore]
        public int MissedNotes { get => Score != null ? Score.MissedNotes : 0; set => Score.MissedNotes = value; }
        [NotMapped]
        [JsonIgnore]
        public int BombCuts { get => Score != null ? Score.BombCuts : 0; set => Score.BombCuts = value; }
        [NotMapped]
        [JsonIgnore]
        public int WallsHit { get => Score != null ? Score.WallsHit : 0; set => Score.WallsHit = value; }
        [NotMapped]
        [JsonIgnore]
        public int Pauses { get => Score != null ? Score.Pauses : 0; set => Score.Pauses = value; }
        [NotMapped]
        [JsonIgnore]
        public bool FullCombo { get => Score != null ? Score.FullCombo : false; set => Score.FullCombo = value; }
        [NotMapped]
        [JsonIgnore]
        public HMD Hmd { get => Score != null ? Score.Hmd : HMD.unknown; set => Score.Hmd = value; }
        [NotMapped]
        [JsonIgnore]
        public ControllerEnum Controller { get => Score != null ? Score.Controller : ControllerEnum.unknown; set => Score.Controller = value; }
        [NotMapped]
        [JsonIgnore]
        public float AccRight { get => Score != null ? Score.AccRight : 0; set => Score.AccRight = value; }
        [NotMapped]
        [JsonIgnore]
        public float AccLeft { get => Score != null ? Score.AccLeft : 0; set => Score.AccLeft = value; }
        [NotMapped]
        [JsonIgnore]
        public int? MaxStreak { get => Score != null ? Score.MaxStreak : 0; set => Score.MaxStreak = value; }
        [NotMapped]
        [JsonIgnore]
        public float FcAccuracy { get => Score != null ? Score.FcAccuracy : 0; set => Score.FcAccuracy = value; }
        [NotMapped]
        [JsonIgnore]
        public float FcPp { get => Score != null ? Score.FcPp : 0; set => Score.FcPp = value; }
        [NotMapped]
        [JsonIgnore]
        public int PlayCount { get => Score != null ? Score.PlayCount : 0; set => Score.PlayCount = value; }
        [NotMapped]
        [JsonIgnore]
        public int LastTryTime { get => Score != null ? Score.LastTryTime : 0; set => Score.LastTryTime = value; }
        [NotMapped]
        [JsonIgnore]
        public float LeftTiming { get => Score != null ? Score.LeftTiming : 0; set => Score.LeftTiming = value; }
        [NotMapped]
        [JsonIgnore]
        public float RightTiming { get => Score != null ? Score.RightTiming : 0; set => Score.RightTiming = value; }
        [NotMapped]
        [JsonIgnore]
        public bool Suspicious { get => Score != null ? Score.Suspicious : false; set => Score.Suspicious = value; }
        [NotMapped]
        [JsonIgnore]
        public bool IgnoreForStats { get => Score != null ? Score.IgnoreForStats : false; set => Score.IgnoreForStats = value; }
        [NotMapped]
        [JsonIgnore]
        public int AuthorizedReplayWatched { get => Score != null ? Score.AuthorizedReplayWatched : 0; set => Score.AuthorizedReplayWatched = value; }
        [NotMapped]
        [JsonIgnore]
        public int AnonimusReplayWatched { get => Score != null ? Score.AnonimusReplayWatched : 0; set => Score.AnonimusReplayWatched = value; }
        [NotMapped]
        [JsonIgnore]
        public ReplayOffsets? ReplayOffsets { get => Score != null ? Score.ReplayOffsets : null; set => Score.ReplayOffsets = value; }
        [NotMapped]
        [JsonIgnore]
        public RankVoting? RankVoting { get => Score != null ? Score.RankVoting : null; set => Score.RankVoting = value; }
        [NotMapped]
        [JsonIgnore]
        public ScoreMetadata? Metadata { get => Score != null ? Score.Metadata : null; set => Score.Metadata = value; }
        [NotMapped]
        [JsonIgnore]
        public string Time { get => Timepost.ToString(); set => Timepost = 0; }
    }
}
