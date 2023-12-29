namespace BeatLeader.Models;

public class Playlist {
    public int Id { get; set; }
    public bool IsShared { get; set; }
    public required string Link { get; set; }
    public required string OwnerId { get; set; }
    public string? Hash { get; set; }
}