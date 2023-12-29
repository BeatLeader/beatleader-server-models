namespace BeatLeader.Models;

public class PlayerSocial {
    public int Id { get; set; }
    public required string Service { get; set; }
    public required string Link { get; set; }
    public required string User { get; set; }

    public required string UserId { get; set; }
    public string? PlayerId { get; set; }
}