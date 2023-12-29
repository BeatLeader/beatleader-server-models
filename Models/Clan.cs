using System.ComponentModel.DataAnnotations.Schema;

namespace BeatLeader.Models;

public class Clan {
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Color { get; set; }
    public required string Icon { get; set; }
    public required string Tag { get; set; }
    public required string LeaderID { get; set; }
    public required string Description { get; set; }
    public required string Bio { get; set; }
    public int PlayersCount { get; set; }
    public float Pp { get; set; }
    public float AverageRank { get; set; }
    public float AverageAccuracy { get; set; }

    public int CaptureLeaderboardsCount { get; set; }
    public float RankedPoolPercentCaptured { get; set; }
    public ICollection<Leaderboard>? CapturedLeaderboards { get; set; }

    public ICollection<Player> Players { get; set; } = new List<Player>();

    [InverseProperty("ClanRequest")]
    public ICollection<User> Requests { get; set; } = new List<User>();

    [InverseProperty("BannedClans")]
    public ICollection<User> Banned { get; set; } = new List<User>();
}

public class ReservedClanTag {
    public int Id { get; set; }
    public required string Tag { get; set; }
}