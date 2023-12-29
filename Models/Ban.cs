namespace BeatLeader.Models;

public class Ban {
    public int Id { get; set; }
    public required string PlayerId { get; set; }
    public required string BannedBy { get; set; }
    public required string BanReason { get; set; }
    public int Timeset { get; set; }
    public int Duration { get; set; }
}