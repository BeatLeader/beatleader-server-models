using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json.Serialization;

namespace BeatLeader.Models;

public class PlayerChange {
    public int Id { get; set; }
    public int Timestamp { get; set; }
    public string? PlayerId { get; set; }

    public string? OldName { get; set; }
    public string? NewName { get; set; }

    public string? OldCountry { get; set; }
    public string? NewCountry { get; set; }

    public string? Changer { get; set; }
}

public interface IPlayer {
    public string Name { get; set; }
    public string Country { get; set; }
    public float Pp { get; set; }
    public float AccPp { get; set; }
    public float TechPp { get; set; }
    public float PassPp { get; set; }
    public int Rank { get; set; }
    public int CountryRank { get; set; }

    public float LastWeekPp { get; set; }
    public int LastWeekRank { get; set; }
    public int LastWeekCountryRank { get; set; }
    public PlayerScoreStats? ScoreStats { get; set; }
    public bool Banned { get; set; }
}

[Index(nameof(Banned), IsUnique = false)]
public class Player : IPlayer {
    [Key]
    public required string Id { get; set; }
    public string Platform { get; set; } = "";
    public string Avatar { get; set; } = "";

    public string Role { get; set; } = "";
    public int MapperId { get; set; }
    public bool Bot { get; set; }
    public bool Inactive { get; set; }

    public string ExternalProfileUrl { get; set; } = "";
    public ICollection<Clan>? Clans { get; set; }
    public string ClanOrder { get; set; } = "";
    public ICollection<PlayerFriends>? Friends { get; set; }

    public ICollection<Badge>? Badges { get; set; }

    [JsonIgnore]
    public DeveloperProfile? DeveloperProfile { get; set; }

    public PatreonFeatures? PatreonFeatures { get; set; }
    public ProfileSettings? ProfileSettings { get; set; }
    public ICollection<PlayerChange>? Changes { get; set; }

    public ICollection<PlayerScoreStatsHistory>? History { get; set; }

    public ICollection<EventPlayer>? EventsParticipating { get; set; }
    public ICollection<PlayerSocial>? Socials { get; set; }
    public ICollection<Achievement>? Achievements { get; set; }
    public ICollection<PlayerContextExtension>? ContextExtensions { get; set; }
    public ICollection<ReeSabersPreset>? Presets { get; set; }
    public string Name { get; set; } = "";
    public string Country { get; set; } = "not set";

    public float Pp { get; set; }
    public float AccPp { get; set; }
    public float TechPp { get; set; }
    public float PassPp { get; set; }

    public int Rank { get; set; }
    public int CountryRank { get; set; }

    public float LastWeekPp { get; set; }
    public int LastWeekRank { get; set; }
    public int LastWeekCountryRank { get; set; }

    public bool Banned { get; set; }

    public PlayerScoreStats? ScoreStats { get; set; }

    public void SetDefaultAvatar() {
        Avatar = "https://cdn.assets.beatleader.xyz/" + Platform + "avatar.png";
    }

    public void SanitizeName() {
        var characters = new[] { "FDFD", "1242B", "12219", "2E3B", "A9C5", "102A", "0BF5", "0BF8", "E0021" }.Select(
                superWideCharacter => char.ConvertFromUtf32(int.Parse(superWideCharacter, NumberStyles.HexNumber)))
            .ToList();
        Name = Name.Trim();

        foreach (var character in characters) {
            Name = Name.Replace(character, "");

            if (Name.Replace(" ", "").Length == 0) {
                var rnd = new Random();
                Name = "RenamedPlayer" + rnd.Next(1, 100);
            }
        }
    }

    public static bool RoleIsAnySupporter(string role)
        => role.Contains("tipper") ||
            role.Contains("supporter") ||
            role.Contains("sponsor") ||
            role.Contains("booster") ||
            role.Contains("creator") ||
            role.Contains("rankedteam") ||
            role.Contains("qualityteam");

    public bool AnySupporter()
        => RoleIsAnySupporter(Role);
}