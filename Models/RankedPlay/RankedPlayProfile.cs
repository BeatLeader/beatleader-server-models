using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models {
    public enum RankedPlayTier {
        Unranked = 0,    // Not yet calibrated — MMR hidden, treated as 0 in rankings (§5.6)
        Cube = 1,        // 0–899      — below average, bottom tier
        Bronze = 2,      // 900–1499
        Silver = 3,      // 1500–2099  — base tier (seed anchor 1800 = middle of Silver)
        Gold = 4,        // 2100–2999
        Platinum = 5,    // 3000–3899
        Master = 6,      // 3900–4999
        Grandmaster = 7  // 5000+      — no divisions; literal rank number displayed
    }

    [Index(nameof(PlayerId), nameof(SeasonId), IsUnique = true)]
    [Index(nameof(SeasonId), nameof(MMR), IsUnique = false)]
    public class RankedPlayProfile {
        public int Id { get; set; }
        public string? PlayerId { get; set; }
        public Player? Player { get; set; }
        public int? SeasonId { get; set; }
        public RankedPlaySeason? Season { get; set; }

        // Tracked internally even during placement; hidden from clients and
        // treated as 0 in ranking position until IsCalibrated == true (§5.6).
        public float MMR { get; set; }
        public float PeakMMR { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public int CalibrationMatchesPlayed { get; set; }
        public bool IsCalibrated { get; set; }

        public RankedPlayTier Tier { get; set; }
        public int TierDivision { get; set; }       // 3 = III (low) .. 1 = I (high). Ignored for Grandmaster.
        public int? GrandmasterRank { get; set; }   // Populated only when Tier == Grandmaster; literal "GM #N" in UI.

        public int LastMatchTime { get; set; }
        public float DecayedMMR { get; set; }


        [JsonIgnore]
        [InverseProperty("ProfileA")]
        public ICollection<RankedPlayMatch> MatchesAsPlayerA { get; set; }
        [JsonIgnore]
        [InverseProperty("ProfileB")]
        public ICollection<RankedPlayMatch> MatchesAsPlayerB { get; set; }
    }
}
