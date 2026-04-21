using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models
{
    /// <summary>
    /// Represents a player assigned to work on a task
    /// </summary>
    [Index(nameof(WorkTaskId), nameof(PlayerId), IsUnique = true)]
    [Index(nameof(PlayerId), IsUnique = false)]
    public class WorkTaskAssignment : TrackedEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// The work task the player is assigned to
        /// </summary>
        public int WorkTaskId { get; set; }

        [JsonIgnore]
        public WorkTask? WorkTask { get; set; }

        /// <summary>
        /// ID of the assigned player
        /// </summary>
        public string PlayerId { get; set; } = "";

        public Player? Player { get; set; }

        /// <summary>
        /// ID of the player/admin who made the assignment
        /// </summary>
        public string? AssignedById { get; set; }

        [JsonIgnore]
        public Player? AssignedBy { get; set; }

        /// <summary>
        /// Timestamp when the assignment was made
        /// </summary>
        public int AssignedAt { get; set; }

        /// <summary>
        /// Optional role/responsibility description for this assignment
        /// </summary>
        public string? Role { get; set; }

        /// <summary>
        /// Whether this is the primary assignee
        /// </summary>
        public bool IsPrimary { get; set; }
    }
}
