using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeatLeader_Server.Models {
    [Index(nameof(PlayerId), nameof(Context), IsUnique = true)]
    public class PlayerContextExtension : IPlayer, TrackedEntity {
        public int Id { get; set; }
        public LeaderboardContexts Context { get; set; }
        public float Pp { get; set; }
        public float AccPp { get; set; }
        public float TechPp { get; set; }
        public float PassPp { get; set; }
        [NotMapped]
        [JsonIgnore]
        public float AllContextsPp { get => 0; set => PlayerInstance.AllContextsPp = value; }

        public int Rank { get; set; }
        public string Country { get; set; }
        public int CountryRank { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Prestige { get; set; }
        public float LastWeekPp { get; set; }
        public int LastWeekRank { get; set; }
        public int LastWeekCountryRank { get; set; }

        public string PlayerId { get; set; }
        [JsonIgnore]
        [ForeignKey("PlayerId")]
        public Player PlayerInstance { get; set; }
        public PlayerScoreStats? ScoreStats { get; set; }
        public bool Banned { get; set; }

        [NotMapped]
        [JsonIgnore]
        public ICollection<PlayerSearch> Searches { get => PlayerInstance != null ? PlayerInstance.Searches : new List<PlayerSearch>(); set => PlayerInstance.Searches = value;  }

        [NotMapped]
        [JsonIgnore]
        public string Name { get => PlayerInstance != null ? PlayerInstance.Name : ""; set => PlayerInstance.Name = value; }
    }
}
