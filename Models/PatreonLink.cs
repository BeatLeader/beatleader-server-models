namespace BeatLeader.Models;

public class PatreonLink {
    public string Id { get; set; } = null!;
    public string PatreonId { get; set; } = null!;
    public string Token { get; set; } = "";
    public string RefreshToken { get; set; } = "";
    public string Timestamp { get; set; } = "";
    public string Tier { get; set; } = "";
}

public class TwitchLink {
    public string Id { get; set; } = null!;
    public string TwitchId { get; set; } = null!;
    public string Token { get; set; } = "";
    public string RefreshToken { get; set; } = "";
    public string Timestamp { get; set; } = "";
}

public class TwitterLink {
    public string Id { get; set; } = null!;
    public string TwitterId { get; set; } = null!;
    public string Token { get; set; } = "";
    public string RefreshToken { get; set; } = "";
    public string Timestamp { get; set; } = "";
}

public class DiscordLink {
    public string Id { get; set; } = null!;
    public string DiscordId { get; set; } = null!;
    public string Token { get; set; } = "";
    public string RefreshToken { get; set; } = "";
    public string Timestamp { get; set; } = "";
}

public class YouTubeLink {
    public string Id { get; set; } = null!;
    public string GoogleId { get; set; } = null!;
    public string Token { get; set; } = "";
    public string Timestamp { get; set; } = "";
}