namespace BeatLeader.Models;

public class Badge {
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public string Image { get; set; } = null!;
    public string? Link { get; set; }
    public int Timeset { get; set; }
    public bool Hidden { get; set; }
}