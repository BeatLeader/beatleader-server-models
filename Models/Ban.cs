namespace BeatLeader.Models;

public class Ban {
    public int Id { get; set; }
    public string PlayerId { get; set; } = null!;
    public string BannedBy { get; set; } = null!;
    public string BanReason { get; set; } = null!;
    public int Timeset { get; set; }
    public int Duration { get; set; }
}