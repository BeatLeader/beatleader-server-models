using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ReplayDecoder;

namespace BeatLeader_Server.Models
{
    [Index(nameof(PlayerId))]
    [Index(nameof(PlayerId), nameof(LeaderboardId), IsUnique = true)]
    [Index(nameof(Qualification), nameof(Pp), IsUnique = false)]
    [Index(nameof(Timepost))]
    [Index(nameof(Pp))]
    [Index(nameof(Accuracy))]
    [Index(nameof(PlayerId), nameof(Qualification), nameof(Pp), IsUnique = false)]
    public class PredictedScore
    {
        [Key]
        public int Id { get; set; }
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
        public string? Modifiers { get; set; }
        public int BadCuts { get; set; }
        public int MissedNotes { get; set; }
        public int BombCuts { get; set; }
        public int WallsHit { get; set; }
        public bool FullCombo { get; set; }
        public int MaxCombo { get; set; }
        public float FcAccuracy { get; set; }
        public float FcPp { get; set; }
        public float AccRight { get; set; }
        public float AccLeft { get; set; }
        public int Timepost { get; set; }
        public Player Player { get; set; }
        public string LeaderboardId { get; set; }
        public Leaderboard Leaderboard { get; set; }
        public int Priority { get; set; } = 0;
    }
}
