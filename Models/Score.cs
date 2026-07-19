using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ReplayDecoder;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Reflection;

namespace BeatLeader_Server.Models
{
    [Flags]
    public enum LeaderboardContexts
    {
        None = 0,
        General = 1 << 1,
        NoMods = 1 << 2,
        NoPause = 1 << 3,
        Golf = 1 << 4,
        SCPM = 1 << 5,
        Speedrun = 1 << 6,
        SpeedrunBackup = 1 << 7,
        Funny = 1 << 8,
        BackUp = 1 << 9,
        LeftLeader = 1 << 10
    }

    [Flags]
    public enum ScoreStatus
    {
        None = 0,
        PlayOfTheWeek = 1 << 1,
    }

    public static class ContextExtensions {
        public static List<LeaderboardContexts> All =  new List<LeaderboardContexts> { 
            LeaderboardContexts.General,
            LeaderboardContexts.NoMods,
            LeaderboardContexts.NoPause,
            LeaderboardContexts.Golf,
            LeaderboardContexts.SCPM,
        };

        public static List<LeaderboardContexts> NonGeneral = new List<LeaderboardContexts> { 
            LeaderboardContexts.NoMods,
            LeaderboardContexts.NoPause,
            LeaderboardContexts.Golf,
            LeaderboardContexts.SCPM,
            LeaderboardContexts.Speedrun,
            LeaderboardContexts.LeftLeader
        };
    }

    public interface IScore : TrackedEntity {
        public int Id { get; set; }
        public int? ScoreId { get; set; }
        public float Accuracy { get; set; }
        public float Weight { get; set; }
        public int Rank { get; set; }
        public float Pp { get; set; }
        public float PassPP { get; set; }
        public float AccPP { get; set; }
        public float TechPP { get; set; }
        public string Time { get; set; }

        public string? Replay { get; set; }
        public string Platform { get; set; }

        public ScoreStatus Status { get; set; }
        public ICollection<ScoreExternalStatus>? ExternalStatuses { get; set; }
        public int SotwNominations { get; set; }

        public int MaxCombo { get; set; }
        public float BonusPp { get; set; }
        public int BaseScore { get; set; }
        public int ModifiedScore { get; set; }
        public string? Modifiers { get; set; }
        public float ModifiedStars { get; set; }
        public int BadCuts { get; set; }
        public int MissedNotes { get; set; }
        public int BombCuts { get; set; }
        public int WallsHit { get; set; }
        public int Mistakes { get; set; }
        public int Pauses { get; set; }
        public bool FullCombo { get; set; }
        public int Timepost { get; set; }
        public string LeaderboardId { get; set; }
        public Leaderboard Leaderboard { get; set; }
        public HMD Hmd { get; set; }
        public ControllerEnum Controller { get; set; }
        public float AccRight { get; set; }
        public float AccLeft { get; set; }
        public string PlayerId { get; set; }
        public Player Player { get; set; }
        public int? MaxStreak { get; set; }
        public float FcAccuracy { get; set; }
        public float FcPp { get; set; }
        public int Priority { get; set; }
        public LeaderboardContexts ValidContexts { get; set; }

        public bool HasDA { get; set; }
        public bool HasFS { get; set; }
        public bool HasSF { get; set; }
        public bool HasSS { get; set; }
        public bool HasGN { get; set; }
        public bool HasNA { get; set; }
        public bool HasNB { get; set; }
        public bool HasNF { get; set; }
        public bool HasNO { get; set; }
        public bool HasPM { get; set; }
        public bool HasSC { get; set; }
        public bool HasSA { get; set; }
        public bool HasOP { get; set; }
        public bool HasEZ { get; set; }
        public bool HasHD { get; set; }
        public bool HasSMC { get; set; }
        public bool HasOHP { get; set; }
        public bool HasBSF { get; set; }
        public bool HasBFS { get; set; }

        public int PlayCount { get; set; }
        public int LastTryTime { get; set; }
        public float LeftTiming { get; set; }
        public float RightTiming { get; set; }
        public bool Banned { get; set; }
        public bool Bot { get; set; }
        public bool Suspicious { get; set; }
        public bool IgnoreForStats { get; set; }
        public string? Country { get; set; }
        public float Experience { get; set; }

        public float Speed { get; set; }

        public int AuthorizedReplayWatched { get; set; }
        public int AnonimusReplayWatched { get; set; }
        public int ReplayWatchedTotal { get; set; }

        public ScoreImprovement? ScoreImprovement { get; set; }
        public ReplayOffsets? ReplayOffsets { get; set; }
        public RankVoting? RankVoting { get; set; }
        public ScoreMetadata? Metadata { get; set; }
        public Score? ScoreInstance { get; set; }

        public void ModifiersUpdated();
    }

    [Index(nameof(PlayerId))]
    [Index(nameof(PlayerId), nameof(LeaderboardId), nameof(ValidContexts), IsUnique = true)]
    [Index(nameof(PlayerId), nameof(LeaderboardId), nameof(ValidForGeneral), IsUnique = false)]
    [Index(nameof(Banned), nameof(Qualification), nameof(Pp), IsUnique = false)]
    [Index(nameof(Timepost), nameof(Replay))]
    [Index(nameof(Timepost))]
    [Index(nameof(Pp))]
    [Index(nameof(Accuracy))]
    [Index(nameof(PlayerId), nameof(Banned), nameof(Qualification), nameof(Pp), IsUnique = false)]
    [Index(nameof(PlayerId), nameof(Banned), nameof(ValidForGeneral), nameof(Pp), nameof(Timepost), IsUnique = false)]
    [Index(nameof(LeaderboardId), nameof(Banned), nameof(ValidForGeneral), IsUnique = false)]
    public class Score : IScore
    {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        [JsonIgnore]
        public Score? ScoreInstance { get => this; set => _ = value; }
        [NotMapped]
        [JsonIgnore]
        public int? ScoreId { get => Id; set => Id = value ?? 0; }
        [NotMapped]
        [JsonIgnore]
        public string Time { get => Timepost.ToString(); set => Timepost = 0; }
        public int BaseScore { get; set; }
        public int ModifiedScore { get; set; }
        public float Accuracy { get; set; }
        public string PlayerId { get; set; }
        public float Pp { get; set; }
        public float BonusPp { get; set; }
        public float PassPP { get; set; }
        public float AccPP { get; set; }
        public float TechPP { get; set; }
        public bool Qualification { get; set; }
        public float Weight { get; set; }
        public int Rank { get; set; }
        public int CountryRank { get; set; }
        public string? Replay { get; set; } = "";
        public string? Modifiers { get; set; }
        public float ModifiedStars { get; set; }
        public int BadCuts { get; set; }
        public int MissedNotes { get; set; }
        public int BombCuts { get; set; }
        public int WallsHit { get; set; }
        public int Mistakes { get; set; }
        public int Pauses { get; set; }
        public bool FullCombo { get; set; }
        public int MaxCombo { get; set; }
        public float FcAccuracy { get; set; }
        public float FcPp { get; set; }
        public HMD Hmd { get; set; }
        public ControllerEnum Controller { get; set; }
        public float AccRight { get; set; }
        public float AccLeft { get; set; }
        public string? Timeset { get; set; }
        public int Timepost { get; set; }
        public string Platform { get; set; } = "";
        public Player Player { get; set; }
        public LeaderboardContexts ValidContexts { get; set; }
        public bool ValidForGeneral { get; set; }
        public ICollection<ScoreContextExtension> ContextExtensions { get; set; }
        public string LeaderboardId { get; set; }
        public Leaderboard Leaderboard { get; set; }
        public int AuthorizedReplayWatched { get; set; }
        public int AnonimusReplayWatched { get; set; }
        public int ReplayWatchedTotal { get; set; }
        public int? ReplayOffsetsId { get; set; }
        public ReplayOffsets? ReplayOffsets { get; set; }
        public string? Country { get; set; }
        public int? MaxStreak { get; set; } = null;
        public int PlayCount { get; set; } = 1;
        public int LastTryTime { get; set; }
        public float LeftTiming { get; set; }
        public float RightTiming { get; set; }
        public int Priority { get; set; } = 0;
        public int? ScoreImprovementId { get; set; }
        public ScoreImprovement? ScoreImprovement { get; set; }
        public bool Banned { get; set; } = false;
        public bool Suspicious { get; set; } = false;
        public bool Bot { get; set; } = false;
        public bool IgnoreForStats { get; set; } = false;
        public bool Migrated { get; set; } = false;
        public RankVoting? RankVoting { get; set; }
        public ScoreMetadata? Metadata { get; set; }
        public float Experience { get; set; }
        public ScoreStatus Status { get; set; }
        public ICollection<ScoreExternalStatus>? ExternalStatuses { get; set; }
        public int SotwNominations { get; set; }
        public bool LeftHanded { get; set; }
        [JsonIgnore]
        public int StorageTier { get; set; }

        public float Speed { get; set; }

        [JsonIgnore]
        public bool HasDA { get; set; }
        [JsonIgnore]
        public bool HasFS { get; set; }
        [JsonIgnore]
        public bool HasSF { get; set; }
        [JsonIgnore]
        public bool HasSS { get; set; }
        [JsonIgnore]
        public bool HasGN { get; set; }
        [JsonIgnore]
        public bool HasNA { get; set; }
        [JsonIgnore]
        public bool HasNB { get; set; }
        [JsonIgnore]
        public bool HasNF { get; set; }
        [JsonIgnore]
        public bool HasNO { get; set; }
        [JsonIgnore]
        public bool HasPM { get; set; }
        [JsonIgnore]
        public bool HasSC { get; set; }
        [JsonIgnore]
        public bool HasSA { get; set; }
        [JsonIgnore]
        public bool HasOP { get; set; }
        [JsonIgnore]
        public bool HasEZ { get; set; }
        [JsonIgnore]
        public bool HasHD { get; set; }
        [JsonIgnore]
        public bool HasSMC { get; set; }
        [JsonIgnore]
        public bool HasOHP { get; set; }
        [JsonIgnore]
        public bool HasBSF { get; set; }
        [JsonIgnore]
        public bool HasBFS { get; set; }

        public void ModifiersUpdated() {
            if (Modifiers?.Length > 0) {
                var modifiersList = Modifiers.Split(",").Select(m => m.ToUpper()).ToList();
                foreach (var modifier in ModifiersMap.KnownModifiers) {
                    Type scoreType = typeof(Score);                   
                    PropertyInfo? modifierBool = scoreType.GetProperty($"Has{modifier}");
                    if (modifierBool != null) {
                        modifierBool.SetValue(this, modifiersList.Contains(modifier), null);
                    }
                }
            }
        }

        [JsonIgnore]
        [StringLength(25, MinimumLength = 0)]
        public string? HashId { get; set; }

        public void ToContext(ScoreContextExtension? extension) {
            if (extension == null) return;

            Weight = extension.Weight;
            Rank = extension.Rank;
            BaseScore = extension.BaseScore;
            ModifiedScore = extension.ModifiedScore;
            Accuracy = extension.Accuracy;
            Pp = extension.Pp;
            AccPP = extension.AccPP;
            TechPP = extension.TechPP;
            PassPP = extension.PassPP;
            BonusPp = extension.BonusPp;
            Modifiers = extension.Modifiers;
        }
    }

    [Index(nameof(ScoreId), IsUnique = false)]
    public class ReplayWatchingSession {
        public int Id { get; set; }
        public int ScoreId { get; set; }
        public string? IP { get; set; }
        public string? Player { get; set; }
    }
    public class FailedScore
    {
        public int Id { get; set; }
        public int BaseScore { get; set; }
        public int ModifiedScore { get; set; }
        public float Accuracy { get; set; }
        public string PlayerId { get; set; }
        public float Pp { get; set; }
        public float Weight { get; set; }
        public int Rank { get; set; }
        public int CountryRank { get; set; }
        public string Replay { get; set; }
        public string Modifiers { get; set; }
        public int BadCuts { get; set; }
        public int MissedNotes { get; set; }
        public int BombCuts { get; set; }
        public int WallsHit { get; set; }
        public int Pauses { get; set; }
        public bool FullCombo { get; set; }
        public HMD Hmd { get; set; }
        public string Timeset { get; set; }
        public Player Player { get; set; }
        public Leaderboard Leaderboard { get; set; }
        public string Error { get; set; }
        public bool FalsePositive { get; set; }
    }
}
