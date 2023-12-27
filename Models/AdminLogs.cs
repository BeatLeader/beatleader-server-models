namespace BeatLeader.Models;

public class ScoreRemovalLog {
    public int Id { get; set; }
    public string Replay { get; set; } = null!;
    public string AdminId { get; set; } = null!;
    public int Timestamp { get; set; }
}

public class PlayerBanLog {
    public int Id { get; set; }
    public string PlayerId { get; set; } = null!;
    public string AdminId { get; set; } = null!;
    public int Timestamp { get; set; }
}