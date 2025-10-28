using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models
{
    [Index(nameof(Tag), IsUnique = true)]
    public class Clan : TrackedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(10, MinimumLength = 0)]
        public string Color { get; set; }
        public string Icon { get; set; }
        [StringLength(6, MinimumLength = 0)]
        public string Tag { get; set; }
        [StringLength(25, MinimumLength = 0)]
        public string LeaderID { get; set; }
        public string Description { get; set; }
        public string Bio { get; set; }
        public int RichBioTimeset { get; set; }
        [JsonIgnore]
        public string DiscordInvite { get; set; }
        public int PlayersCount { get; set; }
        public int MainPlayersCount { get; set; }
        public float Pp { get; set; }
        public int Rank { get; set; }
        public float AverageRank { get; set; }
        public float AverageAccuracy { get; set; }
        public ICollection<FeaturedPlaylist>? FeaturedPlaylists { get; set; }
        [JsonIgnore]
        [InverseProperty("TopClan")]
        public ICollection<Player> MainPlayers { get; set; } = new List<Player>();
        [JsonIgnore]
        public ICollection<Player> Players { get; set; } = new List<Player>();
        [JsonIgnore]
        [InverseProperty("ClanRequest")]
        public ICollection<User> Requests { get; set; } = new List<User>();
        [JsonIgnore]
        [InverseProperty("BannedClans")]
        public ICollection<User> Banned { get; set; } = new List<User>();
        [JsonIgnore]
        public ICollection<ClanManager>? Managers { get; set; }
        [JsonIgnore]
        public ICollection<ClanUpdate>? Updates { get; set; }
        
        public float RankedPoolPercentCaptured { get; set; }
        public int CaptureLeaderboardsCount { get; set; }
        public ICollection<Leaderboard>? CapturedLeaderboards { get; set; }

        public float GlobalMapX { get; set; }
        public float GlobalMapY { get; set; }
        [JsonIgnore]
        public ICollection<GlobalMapHistory> History { get; set; }

        [JsonIgnore]
        public string? PlayerChangesCallback { get; set; }
        [JsonIgnore]
        public string? ClanRankingDiscordHook { get; set; }
    }

    public class ReservedClanTag
    {
        public int Id { get; set; }
        public string Tag { get; set; }
    }
}
