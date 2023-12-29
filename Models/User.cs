namespace BeatLeader.Models;

public class User {
    public required string Id { get; set; }
    public required Player Player { get; set; }


    public ICollection<Clan> ClanRequest { get; set; } = new List<Clan>();
    public ICollection<Clan> BannedClans { get; set; } = new List<Clan>();
    public ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}

public class OculusUser {
    public required string Name { get; set; }
    public required string Id { get; set; }
    public required string Avatar { get; set; }

    public bool Migrated { get; set; }
    public string? MigratedId { get; set; }
}