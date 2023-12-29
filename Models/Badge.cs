namespace BeatLeader.Models;

public class Badge {
    public int Id { get; set; }
    public required string Description { get; set; }
    public required string Image { get; set; }
    public string? Link { get; set; }
    public int Timeset { get; set; }
    public bool Hidden { get; set; }
}