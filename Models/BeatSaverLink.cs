namespace BeatLeader.Models;

public class BeatSaverLink {
    public string Id { get; set; } = null!;
    public string BeatSaverId { get; set; } = null!;
    public string Token { get; set; } = "";
    public string RefreshToken { get; set; } = "";
    public string Timestamp { get; set; } = "";
}