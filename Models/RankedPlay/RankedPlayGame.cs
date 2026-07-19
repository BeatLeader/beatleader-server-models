using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models {
    // One round inside a best-of-3 RankedPlayMatch. Captures the 5-card hand,
    // the simultaneous discard exchange, the pick, and the play result (§7.3 / §5.3).
    [Index(nameof(MatchId), nameof(RoundNumber), IsUnique = true)]
    [Index(nameof(LeaderboardId), IsUnique = false)]
    public class RankedPlayGame {
        public int Id { get; set; }
        public int MatchId { get; set; }
        [JsonIgnore]
        public RankedPlayMatch? Match { get; set; }

        public int RoundNumber { get; set; }              // 1, 2, or 3

        // Hand snapshot at the start of the discard phase — JSON array of leaderboardIds.
        // Always length 5 going in (refilled from prior round's leftovers, see §7.3.2).
        public string HandJson { get; set; } = "[]";

        // Simultaneous discard phase. null = the player chose to pass.
        public string? PlayerADiscardLeaderboardId { get; set; }
        public string? PlayerBDiscardLeaderboardId { get; set; }

        // Maps drawn to replace the discards (0–2 entries depending on overlap / passes).
        public string ReplacementsJson { get; set; } = "[]";

        public string? PickerId { get; set; }             // PlayerAId in R1/R3, PlayerBId in R2

        public string? LeaderboardId { get; set; }        // The map that was actually played
        [JsonIgnore]
        public Leaderboard? Leaderboard { get; set; }

        // Per-player results — winner is decided by FinalScore (§5.3); accuracy fields
        // are kept for the results-screen display but are NOT used for the winner check.
        public int PlayerAScore { get; set; }             // Raw ModifiedScore (pre-halving)
        public int PlayerBScore { get; set; }
        public int PlayerAFinalScore { get; set; }        // = PlayerAScore / 2 if PlayerAFailed, else PlayerAScore
        public int PlayerBFinalScore { get; set; }
        public float PlayerAAccuracy { get; set; }        // Raw accuracy — UI display only
        public float PlayerBAccuracy { get; set; }

        public bool PlayerAFailed { get; set; }           // Energy reached 0 under NF
        public bool PlayerBFailed { get; set; }
        public bool PlayerAForfeit { get; set; }          // forfeitGame or forfeitMatch sent by player
        public bool PlayerBForfeit { get; set; }

        public string? PlayerAReplay { get; set; }
        public string? PlayerBReplay { get; set; }

        public string? WinnerId { get; set; }             // null on per-round draw
    }
}
