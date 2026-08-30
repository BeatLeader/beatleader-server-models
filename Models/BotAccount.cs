using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models
{
    [Index(nameof(PlayerId), IsUnique = true)]
    [Index(nameof(DeveloperProfileId))]
    public class BotAccount
    {
        public const int MaxPerDeveloper = 3;

        public int Id { get; set; }

        public string PlayerId { get; set; }
        [JsonIgnore]
        [ForeignKey("PlayerId")]
        public Player Player { get; set; }

        public int DeveloperProfileId { get; set; }
        [JsonIgnore]
        public DeveloperProfile DeveloperProfile { get; set; }

        public int CreatedAt { get; set; }
        public int SuspendedAt { get; set; }
    }
}
