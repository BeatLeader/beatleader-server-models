using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models {
    public enum RankedPlayMatchResult {
        Completed = 0,                  // Series played to a winner (2-0 or 2-1)
        Drawn = 1,                      // Series ended 1-1 with a drawn deciding game (or matching forfeits)
        PlayerAForfeitedMatch = 2,      // Player A used forfeitMatch
        PlayerBForfeitedMatch = 3,
        PlayerADisconnected = 4,
        PlayerBDisconnected = 5,
        BothDisconnected = 6,
        Cancelled = 7                   // Map-download failure, server abort — no MMR change
    }

    // A best-of-3 ranked play match. Per-round detail lives on RankedPlayGame children.
    // By convention: PlayerA is the lower-MMR player at match start (round 1 picker per §7.3);
    // PlayerB is the higher-MMR player (round 2 picker). Round 3 if reached returns to PlayerA.
    [Index(nameof(SeasonId), nameof(Timestamp), IsUnique = false)]
    [Index(nameof(PlayerAId), nameof(SeasonId), IsUnique = false)]
    [Index(nameof(PlayerBId), nameof(SeasonId), IsUnique = false)]
    public class RankedPlayMatch {
        public int Id { get; set; }
        public int? SeasonId { get; set; }
        [JsonIgnore]
        public RankedPlaySeason? Season { get; set; }

        public string? PlayerAId { get; set; }
        [JsonIgnore]
        public Player? PlayerA { get; set; }
        public string? PlayerBId { get; set; }
        [JsonIgnore]
        public Player? PlayerB { get; set; }

        // Pre-match MMR snapshot (for display / mmr-history charting).
        public float PlayerAPreMatchMMR { get; set; }
        public float PlayerBPreMatchMMR { get; set; }

        // Best-of-3 series outcome.
        public int PlayerAGamesWon { get; set; }    // 0..2
        public int PlayerBGamesWon { get; set; }    // 0..2
        public int DrawnGames { get; set; }         // 0..3 (per-round ties — see §5.3)
        public string? WinnerId { get; set; }       // null on series draw / both abandoned
        public RankedPlayMatchResult Result { get; set; }

        // MMR change applied once at series end (§5.1).
        public float PlayerAMMRChange { get; set; }
        public float PlayerBMMRChange { get; set; }

        public RankedPlayProfile? ProfileA { get; set; }
        public RankedPlayProfile? ProfileB { get; set; }

        public int Timestamp { get; set; }          // Unix seconds at match start
        public float Duration { get; set; }         // End-to-end seconds (negotiation + all rounds)

        // 2 or 3 game rows per match (early-out at 2-0 → 2 rows; goes to round 3 → 3 rows).
        public ICollection<RankedPlayGame>? Games { get; set; }
    }
}
