using BeatLeader_Server.Models;
using static BeatLeader_Server.Utils.ResponseUtils;

namespace BeatLeader_Server.Utils {

    public class RankedPlayProfileResponse {
        public int Id { get; set; }
        public string PlayerId { get; set; }
        public int SeasonId { get; set; }

        // null while uncalibrated — clients should display "Placement N / 5" instead of a number (§5.6).
        public float? MMR { get; set; }
        public float PeakMMR { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public int CalibrationMatchesPlayed { get; set; }
        public int CalibrationMatchesRemaining { get; set; }
        public bool IsCalibrated { get; set; }

        public RankedPlayTier Tier { get; set; }
        public int TierDivision { get; set; }
        public int? GrandmasterRank { get; set; }
        public int LastMatchTime { get; set; }

        // 1-based MMR rank within the season. 0 while uncalibrated or before any match.
        public int Rank { get; set; }

        public PlayerResponse? Player { get; set; }
        public RankedPlaySeasonResponse? Season { get; set; }
    }

    public class RankedPlayMmrHistoryEntry {
        public int MatchId { get; set; }
        public int Timestamp { get; set; }
        public float MMR { get; set; }
        public float Change { get; set; }
        public bool Win { get; set; }
        public bool Draw { get; set; }
    }

    public class RankedPlayMmrHistoryResponse {
        public int SeasonId { get; set; }
        public float CurrentMMR { get; set; }
        public List<RankedPlayMmrHistoryEntry> Entries { get; set; } = new();
    }

    public class RankedPlaySeasonResponse {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public bool IsActive { get; set; }
    }

    // One round inside a best-of-3 RankedPlayMatchResponse (§7.3).
    public class RankedPlayGameResponse {
        public int Id { get; set; }
        public int RoundNumber { get; set; }

        // Hand + discard exchange snapshot (mostly history-display curiosity).
        public string HandJson { get; set; } = "[]";
        public string? PlayerADiscardLeaderboardId { get; set; }
        public string? PlayerBDiscardLeaderboardId { get; set; }
        public string ReplacementsJson { get; set; } = "[]";

        public string? PickerId { get; set; }

        public string? LeaderboardId { get; set; }
        public LeaderboardResponse? Leaderboard { get; set; }

        // Score is authoritative for the winner check (§5.3). Accuracy is shown
        // alongside it on the results screen but does not drive the comparison.
        public int PlayerAScore { get; set; }
        public int PlayerBScore { get; set; }
        public int PlayerAFinalScore { get; set; }
        public int PlayerBFinalScore { get; set; }
        public float PlayerAAccuracy { get; set; }
        public float PlayerBAccuracy { get; set; }

        public bool PlayerAFailed { get; set; }
        public bool PlayerBFailed { get; set; }
        public bool PlayerAForfeit { get; set; }
        public bool PlayerBForfeit { get; set; }

        public string? PlayerAReplay { get; set; }
        public string? PlayerBReplay { get; set; }

        public string? WinnerId { get; set; }
    }

    public class RankedPlayMatchResponse {
        public int Id { get; set; }
        public int SeasonId { get; set; }

        public string PlayerAId { get; set; }
        public string PlayerBId { get; set; }

        public float PlayerAPreMatchMMR { get; set; }
        public float PlayerBPreMatchMMR { get; set; }

        // Best-of-3 series outcome.
        public int PlayerAGamesWon { get; set; }
        public int PlayerBGamesWon { get; set; }
        public int DrawnGames { get; set; }
        public string? WinnerId { get; set; }
        public RankedPlayMatchResult Result { get; set; }

        public float PlayerAMMRChange { get; set; }
        public float PlayerBMMRChange { get; set; }

        public int Timestamp { get; set; }
        public float Duration { get; set; }

        public PlayerResponse? PlayerA { get; set; }
        public PlayerResponse? PlayerB { get; set; }

        public List<RankedPlayGameResponse> Games { get; set; } = new();
    }

    public class RankedPlayLeaderboardEntry {
        public int Rank { get; set; }
        public float MMR { get; set; }
        public RankedPlayTier Tier { get; set; }
        public int TierDivision { get; set; }
        public int? GrandmasterRank { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public bool IsCalibrated { get; set; }

        public PlayerResponse Player { get; set; }
    }

    // Wrapped variant of the season-leaderboard response that also carries
    // the requesting player's own row (`Self`) so the mod can pin it on
    // screen when their global / country / around rank is outside the
    // visible page. Self is computed against the SAME filters that produced
    // Data, and is null when the player has no profile for the given
    // criteria (or the request is unauthenticated).
    public class RankedPlayLeaderboardResponse {
        public Metadata Metadata { get; set; } = null!;
        public List<RankedPlayLeaderboardEntry> Data { get; set; } = new();
        public RankedPlayLeaderboardEntry? Self { get; set; }
    }

    public class RankedPlayQueueStatusResponse {
        public int PlayersInQueue { get; set; }
        public int ActiveMatches { get; set; }
        public int OnlinePlayers { get; set; }
        public int EstimatedWaitSeconds { get; set; }
    }
}
