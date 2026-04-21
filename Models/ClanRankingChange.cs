using System.ComponentModel.DataAnnotations.Schema;

namespace BeatLeader_Server.Models
{
    public class ClanRankingChange : TrackedEntity
    {
        public int Id { get; set; } // Unique ID for this clanRanking

        public int? OldClanId { get; set; }
        public Clan? OldClan { get; set; } // A clan that has at least one score on this leaderboard
        public int? NewClanId { get; set; }
        public Clan? NewClan { get; set; } // A clan that has at least one score on this leaderboard
        public Score? Score { get; set; }
        public string? LeaderboardId { get; set; } // ID of the leaderboard, useful for quick filtering.
        public Leaderboard? Leaderboard { get; set; } // Leaderboard associated with this clanRanking.
    }
}