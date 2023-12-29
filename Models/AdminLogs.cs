namespace BeatLeader.Models;

public class ScoreRemovalLog {
    public int Id { get; set; }
    public required string Replay { get; set; }
    public required string AdminId { get; set; }
    public int Timestamp { get; set; }
}

public class PlayerBanLog {
    public int Id { get; set; }
    public required string PlayerId { get; set; }
    public required string AdminId { get; set; }
    public int Timestamp { get; set; }
}