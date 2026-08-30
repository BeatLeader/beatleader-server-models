using Microsoft.EntityFrameworkCore;
using ReplayDecoder;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
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
        public bool Banned { get; set; } = false;
        public bool Bot { get; set; } = false;
        public bool BestBot { get; set; } = false;

        public LeaderboardContexts Context { get; set; }
        public ScoreImprovement? ScoreImprovement { get; set; }

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
                    Type scoreType = typeof(ScoreContextExtension);                   
                    PropertyInfo? modifierBool = scoreType.GetProperty($"Has{modifier}");
                    if (modifierBool != null) {
                        modifierBool.SetValue(this, modifiersList.Contains(modifier), null);
                    }
                }
            }
        }

        public float AccRight { get; set; }
        public float AccLeft { get; set; }
        public float FcAccuracy { get; set; }
        public float FcPp { get; set; }


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
        public int Mistakes { get => ScoreInstance != null ? ScoreInstance.Mistakes : 0; set => ScoreInstance.Mistakes = value; }
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
        public int? MaxStreak { get => ScoreInstance != null ? ScoreInstance.MaxStreak : 0; set => ScoreInstance.MaxStreak = value; }
        
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
        public int ReplayWatchedTotal { get => ScoreInstance != null ? ScoreInstance.ReplayWatchedTotal : 0; set => ScoreInstance.ReplayWatchedTotal = value; }
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
        [NotMapped]
        [JsonIgnore]
        public float Experience { get => ScoreInstance != null ? ScoreInstance.Experience : 0; set => ScoreInstance.Experience = value; }
        [NotMapped]
        [JsonIgnore]
        public ScoreStatus Status { get => ScoreInstance != null ? ScoreInstance.Status : ScoreStatus.None; set => ScoreInstance.Status = value; }
        [NotMapped]
        [JsonIgnore]
        public ICollection<ScoreExternalStatus>? ExternalStatuses { get => ScoreInstance != null ? ScoreInstance.ExternalStatuses : null; set => ScoreInstance.ExternalStatuses = value; }
        [NotMapped]
        [JsonIgnore]
        public int SotwNominations { get => ScoreInstance != null ? ScoreInstance.SotwNominations : 0; set => ScoreInstance.SotwNominations = value; }

        [NotMapped]
        [JsonIgnore]
        public float Speed { get => ScoreInstance != null ? ScoreInstance.Speed : 0; set => ScoreInstance.Speed = value; }
        [NotMapped]
        [JsonIgnore]
        public LeaderboardContexts ValidContexts { get => ScoreInstance != null ? ScoreInstance.ValidContexts : LeaderboardContexts.None; set => ScoreInstance.ValidContexts = value; }
    }
}
