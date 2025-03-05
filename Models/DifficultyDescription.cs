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
        V3Pepega = 1 << 9
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


        public int SpeedTags { get; set; }
        public int StyleTags { get; set; }
        public int FeatureTags { get; set; }
        

        public float? Stars { get; set; }
        public float? PredictedAcc { get; set; }
        public float? PassRating { get; set; }
        public float? AccRating { get; set; }
        public float? TechRating { get; set; }
        public int Type { get; set; }

        public float Njs { get; set; }
        public float Nps { get; set; }
        public int Notes { get; set; }
        public int Chains { get; set; }
        public int Sliders { get; set; }
        public int Bombs { get; set; }
        public int Walls { get; set; }
        public int MaxScore { get; set; }
        public double Duration { get; set; }

        public Requirements Requirements { get; set; }

        public void HideRatings() {
            this.AccRating = null;
            this.TechRating = null;
            this.PassRating = null;
            this.Stars = null;

            this.ModifiersRating = null;
        }
    }
}
