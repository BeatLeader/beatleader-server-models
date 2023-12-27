using System.ComponentModel.DataAnnotations.Schema;

namespace BeatLeader.Models;

public class Clan {
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Color { get; set; } = null!;
    public string Icon { get; set; } = null!;
    public string Tag { get; set; } = null!;
    public string LeaderID { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Bio { get; set; } = null!;
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
    public string Tag { get; set; } = null!;
}