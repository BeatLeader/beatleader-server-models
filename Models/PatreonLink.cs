namespace BeatLeader.Models;

public class PatreonLink {
    public required string Id { get; set; }
    public required string PatreonId { get; set; }
    public string Token { get; set; } = "";
    public string RefreshToken { get; set; } = "";
    public string Timestamp { get; set; } = "";
    public string Tier { get; set; } = "";
}

public class TwitchLink {
    public required string Id { get; set; }
    public required string TwitchId { get; set; }
    public string Token { get; set; } = "";
    public string RefreshToken { get; set; } = "";
    public string Timestamp { get; set; } = "";
}

public class TwitterLink {
    public required string Id { get; set; }
    public required string TwitterId { get; set; }
    public string Token { get; set; } = "";
    public string RefreshToken { get; set; } = "";
    public string Timestamp { get; set; } = "";
}

public class DiscordLink {
    public required string Id { get; set; }
    public required string DiscordId { get; set; }
    public string Token { get; set; } = "";
    public string RefreshToken { get; set; } = "";
    public string Timestamp { get; set; } = "";
}

public class YouTubeLink {
    public required string Id { get; set; }
    public required string GoogleId { get; set; }
    public string Token { get; set; } = "";
    public string Timestamp { get; set; } = "";
}