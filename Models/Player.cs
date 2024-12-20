using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models {
    public interface IPlayer {
        public string Name { get; set; }
        public string Country { get; set; }
        public float Pp { get; set; }
        public float AccPp { get; set; }
        public float TechPp { get; set; }
        public float PassPp { get; set; }
        public float AllContextsPp { get; set; }
        public int Rank { get; set; }
        public int CountryRank { get; set; }

        public float LastWeekPp { get; set; }
        public int LastWeekRank { get; set; }
        public int LastWeekCountryRank { get; set; }
        public PlayerScoreStats? ScoreStats { get; set; }
        public bool Banned { get; set; }
        public ICollection<PlayerSearch> Searches { get; set; }
        public Player PlayerInstance { get; set; }
    }

    [Index(nameof(Banned), IsUnique = false)]
    [Index(nameof(Id), nameof(Alias), nameof(OldAlias), IsUnique = false)]
    [Index(nameof(Rank), IsUnique = false)]
    [Index(nameof(Banned), nameof(Pp), nameof(ScoreStatsId), IsUnique = false)]
    public class Player : IPlayer, StringTrackedEntity {
        [Key]
        public string Id { get; set; }
        [StringLength(80, MinimumLength = 0)]
        public string Name { get; set; } = "";
        public string Platform { get; set; } = "";
        public string Avatar { get; set; } = "";
        public string WebAvatar { get; set; } = "";
        public string Country { get; set; } = "not set";
        
        [StringLength(40, MinimumLength = 0)]
        public string? Alias { get; set; }
        [StringLength(40, MinimumLength = 0)]
        public string? OldAlias { get; set; }

        public string Role { get; set; } = "";
        public int? MapperId { get; set; }
        public Mapper? Mapper { get; set; }

        public float Pp { get; set; }
        public float AccPp { get; set; }
        public float TechPp { get; set; }
        public float PassPp { get; set; }
        public float AllContextsPp { get; set; }

        public int Rank { get; set; }
        public int CountryRank { get; set; }

        public float LastWeekPp { get; set; }
        public int LastWeekRank { get; set; }
        public int LastWeekCountryRank { get; set; }

        public bool Banned { get; set; }
        public bool Bot { get; set; }
        public bool Inactive { get; set; }

        public string ExternalProfileUrl { get; set; } = "";
        public int RichBioTimeset { get; set; }
        public int CreatedAt { get; set; }
        public int SpeedrunStart { get; set; }

        public int? ScoreStatsId { get; set; }
        public PlayerScoreStats? ScoreStats { get; set; }
        [JsonIgnore]
        public ICollection<Clan>? Clans { get; set; }
        [JsonIgnore]
        public ICollection<ClanManager>? ManagingClans { get; set; }
        public string ClanOrder { get; set; } = "";
        [JsonIgnore]
        public ICollection<PlayerFriends>? Friends { get; set; }

        public ICollection<Badge>? Badges { get; set; }

        [JsonIgnore]
        public DeveloperProfile? DeveloperProfile { get; set; }

        public PatreonFeatures? PatreonFeatures { get; set; }
        public ProfileSettings? ProfileSettings { get; set; }
        public ICollection<PlayerChange>? Changes { get; set; }

        public ICollection<EventPlayer>? EventsParticipating { get; set; }
        public ICollection<PlayerSocial>? Socials { get; set; }
        public ICollection<Achievement>? Achievements { get; set; }
        [JsonIgnore]
        public ICollection<PlayerContextExtension>? ContextExtensions { get; set; }
        [JsonIgnore]
        public ICollection<ReeSabersPreset>? Presets { get; set; }
        [JsonIgnore]
        public ICollection<PlayerSearch> Searches { get; set; }

        [JsonIgnore]
        public ICollection<PlayerTreeOrnament> Ornaments { get; set; }
        [NotMapped]
        [JsonIgnore]
        public Player PlayerInstance { get => this; set => _ = value; }

        public void SetDefaultAvatar() {
            this.Avatar = "https://cdn.assets.beatleader.com/" + this.Platform + "avatar.png";
        }

        public void SanitizeName() {
            var characters = (new string[] { "FDFD", "1242B", "12219", "2E3B", "A9C5", "102A", "0BF5", "0BF8", "E0021" }).Select(
                superWideCharacter => char.ConvertFromUtf32(int.Parse(superWideCharacter, System.Globalization.NumberStyles.HexNumber)))
                .ToList();
            Name = Name.Trim();
            foreach (var character in characters) {
                Name = Name.Replace(character, "");
                if (Name.Replace(" ", "").Length == 0) {
                    Random rnd = new Random();
                    Name = "RenamedPlayer" + rnd.Next(1, 100);
                }
            }
        }

        public static bool RoleIsAnySupporter(string? role) {
            return role != null && (role.Contains("tipper") ||
            role.Contains("supporter") ||
            role.Contains("sponsor") ||
            role.Contains("booster") ||
            role.Contains("creator") ||
            role.Contains("rankedteam") || 
            role.Contains("qualityteam"));
        }

        public static bool RoleIsAnyTeam(string? role) {
            return role != null && (
            role.Contains("creator") ||
            role.Contains("rankedteam") || 
            role.Contains("qualityteam"));
        }

        public bool AnySupporter() {
            return RoleIsAnySupporter(Role);
        }
        
        public void RefreshClanOrder() {
            ClanOrder = string.Join(",", Clans
                 .OrderBy(c => ClanOrder.IndexOf(c.Tag) >= 0 ? ClanOrder.IndexOf(c.Tag) : 1000)
                 .Select(c => c.Tag));
        }
    }
}
