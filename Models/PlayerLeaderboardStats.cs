using Microsoft.EntityFrameworkCore;
using ReplayDecoder;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models {
    public enum EndType {
        Unknown = 0,
        Clear = 1,
        Fail = 2,
        Restart = 3,
        Quit = 4,
        Practice = 5
    }

    [Index(nameof(PlayerId), nameof(LeaderboardId), nameof(Timeset), IsUnique = false)]
    [Index(nameof(PlayerId), nameof(ScoreId), IsUnique = false)]
    public class PlayerLeaderboardStats : TrackedEntity {
        public int Id { get; set; }
        [StringLength(25, MinimumLength = 0)]
        public string PlayerId { get; set; }
        public EndType Type { get; set; }
        public int Timeset { get; set; }
        public float Time { get; set; }
        public float StartTime { get; set; }
        public float Speed { get; set; }
        public int Score { get; set; }

        [StringLength(200, MinimumLength = 0)]
        public string? Replay { get; set; }

        [StringLength(40, MinimumLength = 0)]
        public string LeaderboardId { get; set; }

        public int? ScoreId { get; set; }
        public int BaseScore { get; set; }
        public int ModifiedScore { get; set; }
        public float Accuracy { get; set; }
        public float Pp { get; set; }
        public float BonusPp { get; set; }
        public float PassPP { get; set; }
        public float AccPP { get; set; }
        public float TechPP { get; set; }
        public bool Qualification { get; set; }
        public float Weight { get; set; }
        public int Rank { get; set; }
        public int CountryRank { get; set; }
        public string? Modifiers { get; set; }
        [StringLength(100, MinimumLength = 0)]
        public string ModifiersList { get; set; } = "";
        public int BadCuts { get; set; }
        public int MissedNotes { get; set; }
        public int BombCuts { get; set; }
        public int WallsHit { get; set; }
        public int Pauses { get; set; }
        public bool FullCombo { get; set; }
        public int MaxCombo { get; set; }
        public float FcAccuracy { get; set; }
        public float FcPp { get; set; }
        public HMD Hmd { get; set; }
        public ControllerEnum Controller { get; set; }
        public float AccRight { get; set; }
        public float AccLeft { get; set; }
        public int Timepost { get; set; }
        public string Platform { get; set; } = "";
        public int AuthorizedReplayWatched { get; set; }
        public int AnonimusReplayWatched { get; set; }
        public int? ReplayOffsetsId { get; set; }
        public ReplayOffsets? ReplayOffsets { get; set; }
        public ScoreMetadata? Metadata { get; set; }
        public string? Country { get; set; }
        public int? MaxStreak { get; set; } = null;
        public float LeftTiming { get; set; }
        public float RightTiming { get; set; }
        public int Priority { get; set; } = 0;
        public int AttemptsCount { get; set; }
        public float Experience { get; set; }

        public int? ScoreImprovementId { get; set; }
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

        public void FromScore(Score score) {
            ScoreId = score.Id;
            BaseScore = score.BaseScore;
            ModifiedScore = score.ModifiedScore;
            Accuracy = score.Accuracy;
            Pp = score.Pp;
            BonusPp = score.BonusPp;
            PassPP = score.PassPP;
            AccPP = score.AccPP;
            TechPP = score.TechPP;
            Qualification = score.Qualification;
            Weight = score.Weight;
            Rank = score.Rank;
            CountryRank = score.CountryRank;
            ModifiersList = score.Modifiers ?? "";
            BadCuts = score.BadCuts;
            MissedNotes = score.MissedNotes;
            BombCuts = score.BombCuts;
            WallsHit = score.WallsHit;
            Pauses = score.Pauses;
            FullCombo = score.FullCombo;
            MaxCombo = score.MaxCombo;
            FcAccuracy = score.FcAccuracy;
            FcPp = score.FcPp;
            Hmd = score.Hmd;
            Controller = score.Controller;
            AccRight = score.AccRight;
            AccLeft = score.AccLeft;
            Timepost = score.Timepost;
            Platform = score.Platform;
            AuthorizedReplayWatched = score.AuthorizedReplayWatched;
            AnonimusReplayWatched = score.AnonimusReplayWatched;
            ReplayOffsetsId = score.ReplayOffsetsId;
            Country = score.Country;
            MaxStreak = score.MaxStreak;
            LeftTiming = score.LeftTiming;
            RightTiming = score.RightTiming;
            Priority = score.Priority;
            Experience = score.Experience;
            if (score.ReplayOffsets != null) {
                ReplayOffsets = new ReplayOffsets {
                    Frames = score.ReplayOffsets.Frames,
                    Notes = score.ReplayOffsets.Notes,
                    Walls = score.ReplayOffsets.Walls,
                    Heights = score.ReplayOffsets.Heights,
                    Pauses = score.ReplayOffsets.Pauses,
                };
            }

            if (score.Metadata != null) {
                Metadata = new ScoreMetadata {
                    PinnedContexts = score.Metadata.PinnedContexts,
                    HighlightedInfo = score.Metadata.HighlightedInfo,
                    Priority = score.Metadata.Priority,
                    Description = score.Metadata.Description,

                    LinkService = score.Metadata.LinkService,
                    LinkServiceIcon = score.Metadata.LinkServiceIcon,
                    Link = score.Metadata.Link
                };
            }

            if (score.ScoreImprovement != null) {
                ScoreImprovement = new ScoreImprovement { 
                    Timeset = score.ScoreImprovement.Timeset,
                    Score = score.ScoreImprovement.Score,
                    Accuracy = score.ScoreImprovement.Accuracy,
                    Pp = score.ScoreImprovement.Pp,
                    BonusPp = score.ScoreImprovement.BonusPp,
                    Rank = score.ScoreImprovement.Rank,
                    AccRight = score.ScoreImprovement.AccRight,
                    AccLeft = score.ScoreImprovement.AccLeft,

                    AverageRankedAccuracy = score.ScoreImprovement.AverageRankedAccuracy,
                    TotalPp = score.ScoreImprovement.TotalPp,
                    TotalRank = score.ScoreImprovement.TotalRank,

                    BadCuts = score.ScoreImprovement.BadCuts,
                    MissedNotes = score.ScoreImprovement.MissedNotes,
                    BombCuts = score.ScoreImprovement.BombCuts,
                    WallsHit = score.ScoreImprovement.WallsHit,
                    Pauses = score.ScoreImprovement.Pauses,
                    Modifiers = score.ScoreImprovement.Modifiers
                };
            }

            HasDA = score.HasDA;
            HasFS = score.HasFS;
            HasSF = score.HasSF;
            HasSS = score.HasSS;
            HasGN = score.HasGN;
            HasNA = score.HasNA;
            HasNB = score.HasNB;
            HasNF = score.HasNF;
            HasNO = score.HasNO;
            HasPM = score.HasPM;
            HasSC = score.HasSC;
            HasSA = score.HasSA;
            HasOP = score.HasOP;
            HasEZ = score.HasEZ;
            HasHD = score.HasHD;
            HasSMC = score.HasSMC;
            HasOHP = score.HasOHP;
            HasBSF = score.HasBFS;
            HasBFS = score.HasBSF;
        }
    }
}
