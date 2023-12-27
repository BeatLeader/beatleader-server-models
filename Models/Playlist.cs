namespace BeatLeader.Models;

public class Playlist {
    public int Id { get; set; }
    public bool IsShared { get; set; }
    public string Link { get; set; } = null!;
    public string OwnerId { get; set; } = null!;
    public string? Hash { get; set; }
}