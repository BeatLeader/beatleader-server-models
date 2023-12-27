namespace BeatLeader.Models;

public class User {
    public string Id { get; set; } = null!;
    public Player Player { get; set; } = null!;


    public ICollection<Clan> ClanRequest { get; set; } = new List<Clan>();
    public ICollection<Clan> BannedClans { get; set; } = new List<Clan>();
    public ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}

public class OculusUser {
    public string Name { get; set; } = null!;
    public string Id { get; set; } = null!;
    public string Avatar { get; set; } = null!;

    public bool Migrated { get; set; }
    public string? MigratedId { get; set; }
}