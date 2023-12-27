namespace BeatLeader.Models;

public class PlayerSocial {
    public int Id { get; set; }
    public string Service { get; set; } = null!;
    public string Link { get; set; } = null!;
    public string User { get; set; } = null!;

    public string UserId { get; set; } = null!;
    public string? PlayerId { get; set; }
}