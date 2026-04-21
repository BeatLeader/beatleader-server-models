using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models
{
    /// <summary>
    /// Represents a status that can be applied to work tasks (e.g., Open, In Progress, Resolved)
    /// </summary>
    public class WorkTaskStatus : TrackedEntity
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; } = "";

        [StringLength(500)]
        public string? Description { get; set; }

        /// <summary>
        /// Icon URL or icon identifier
        /// </summary>
        public string? Icon { get; set; }

        /// <summary>
        /// Color for UI display (hex format, e.g., "#FF5733")
        /// </summary>
        [StringLength(10)]
        public string? Color { get; set; }

        /// <summary>
        /// Display order for sorting statuses
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Whether this status marks the task as closed/completed
        /// </summary>
        public bool IsClosedStatus { get; set; }

        /// <summary>
        /// Whether this is the default status for new tasks
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Timestamp when this status was created
        /// </summary>
        public int CreatedAt { get; set; }

        /// <summary>
        /// ID of the admin who created this status
        /// </summary>
        public string? CreatedById { get; set; }

        [JsonIgnore]
        public Player? CreatedBy { get; set; }

        /// <summary>
        /// Tasks currently in this status
        /// </summary>
        [JsonIgnore]
        public ICollection<WorkTask>? Tasks { get; set; }
    }
}
