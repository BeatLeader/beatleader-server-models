using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models
{
    /// <summary>
    /// Represents the difficulty status of a map.
    /// </summary>
    public enum DifficultyStatus
    {
        /// <summary>Unranked (0)</summary>
        unranked = 0,
        /// <summary>Nominated (1)</summary>
        nominated = 1,
        /// <summary>Qualified (2)</summary>
        qualified = 2,
        /// <summary>Ranked (3)</summary>
        ranked = 3,
        /// <summary>Unrankable (4)</summary>
        unrankable = 4,
        /// <summary>Outdated (5)</summary>
        outdated = 5,
        /// <summary>In Event (6)</summary>
        inevent = 6,
        /// <summary>Official Soundtrack (7)</summary>
        OST = 7
    }

    [Flags]
    public enum Requirements
    {
        Ignore = -1,
        None = 0,
        Chroma = 1 << 1,
        Noodles = 1 << 2,
        MappingExtensions = 1 << 3,
        Cinema = 1 << 4,
        V3 = 1 << 5,
        OptionalProperties = 1 << 6,
        VNJS = 1 << 7,
        Vivify = 1 << 8,
        V3Pepega = 1 << 9,
        GroupLighting = 1 << 10,
        AudioLink = 1 << 11
    }

    [Flags]
    public enum MapTypes
    {
        None = 0,
        Acc = 1,
        Tech = 2,
        Midspeed = 4,
        Speed = 8,
        Fitbeat = 16,
        Linear = 32,
        BombReset = 64
    }

    public class DifficultyDescriptionExtension {
        public int Id { get; set; }
        public LeaderboardContexts Context { get; set; }
        public int MaxScoreRight { get; set; }
        public int MaxScoreLeft { get; set; }
    }

    [Index(nameof(Status), IsUnique = false)]
    [Index(nameof(Hash), nameof(ModeName), nameof(DifficultyName), IsUnique = false)]
    public class DifficultyDescription
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int Mode { get; set; }
        [StringLength(25, MinimumLength = 0)]
        public string DifficultyName { get; set; }
        [StringLength(100, MinimumLength = 0)]
        public string ModeName { get; set; }
        public DifficultyStatus Status { get; set; }
        public ModifiersMap? ModifierValues { get; set; } = new ModifiersMap();
        public ModifiersRating? ModifiersRating { get; set; }
        [JsonIgnore]
        public MaxScoreGraph? MaxScoreGraph { get; set; }
        public int NominatedTime { get; set; }
        public int QualifiedTime { get; set; }
        public int RankedTime { get; set; }

        [StringLength(80, MinimumLength = 0)]
        public string Hash { get; set; } = "";
        public string? SongId { get; set; }

        public string? CustomDifficultyName { get; set; }

        public int SpeedTags { get; set; }
        public int StyleTags { get; set; }
        public int FeatureTags { get; set; }
        

        public float? Stars { get; set; }
        public float? PredictedAcc { get; set; }
        public float? PassRating { get; set; }
        public float? AccRating { get; set; }
        public float? TechRating { get; set; }

        public float? MultiRating { get; set; }
        public float? LinearPercentage { get; set; }
        public float? PeakSustainedEBPM { get; set; }

        public float Njs { get; set; }
        public float Nps { get; set; }
        public int Notes { get; set; }
        public int Chains { get; set; }
        public int Sliders { get; set; }
        public int Bombs { get; set; }
        public int Walls { get; set; }
        public int MaxScore { get; set; }
        public double Duration { get; set; }
        public double NoteJumpStartBeatOffset { get; set; }
        [StringLength(25, MinimumLength = 0)]
        public string? MapVersion { get; set; }

        public Requirements Requirements { get; set; }
        [JsonIgnore]
        public bool RequiresChroma { get; set; }
        [JsonIgnore]
        public bool RequiresNoodles { get; set; }
        [JsonIgnore]
        public bool RequiresMappingExtensions { get; set; }
        [JsonIgnore]
        public bool RequiresCinema { get; set; }
        [JsonIgnore]
        public bool RequiresV3 { get; set; }
        [JsonIgnore]
        public bool RequiresOptionalProperties { get; set; }
        [JsonIgnore]
        public bool RequiresVNJS { get; set; }
        [JsonIgnore]
        public bool RequiresVivify { get; set; }
        [JsonIgnore]
        public bool RequiresV3Pepega { get; set; }
        [JsonIgnore]
        public bool RequiresGroupLighting { get; set; }
        [JsonIgnore]
        public bool RequiresAudioLink { get; set; }

        public MapTypes Type { get; set; }
        [JsonIgnore]
        public bool TypeAcc { get; set; }
        [JsonIgnore]
        public bool TypeTech { get; set; }
        [JsonIgnore]
        public bool TypeMidspeed { get; set; }
        [JsonIgnore]
        public bool TypeSpeed { get; set; }
        [JsonIgnore]
        public bool TypeFitbeat { get; set; }
        [JsonIgnore]
        public bool TypeLinear { get; set; }
        [JsonIgnore]
        public bool TypeBombReset { get; set; }
        public int? DifficultyStatisticsId { get; set; }
        [JsonIgnore]
        public DifficultyStatistics? DifficultyStatistics { get; set; }

        public ICollection<DifficultyDescriptionExtension> Extensions { get; set; }

        public void HideRatings() {
            this.AccRating = null;
            this.TechRating = null;
            this.PassRating = null;
            this.Stars = null;

            this.ModifiersRating = null;
        }
    }
}
