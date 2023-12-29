namespace BeatLeader.Models;

public class AuthInfo {
    public int Id { get; set; }
    public required string Password { get; set; }
    public required string Login { get; set; }
}