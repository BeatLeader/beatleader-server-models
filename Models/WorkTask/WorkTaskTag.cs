using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models
{
    /// <summary>
    /// Represents a tag that can be applied to work tasks for categorization
    /// </summary>
    public class WorkTaskTag : TrackedEntity
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
        /// Optional link for more information about this tag
        /// </summary>
        public string? Link { get; set; }

        /// <summary>
        /// Color for UI display (hex format, e.g., "#FF5733")
        /// </summary>
        [StringLength(10)]
        public string? Color { get; set; }

        /// <summary>
        /// If true, only admins can add this tag to tasks. If false, any player can add it.
        /// </summary>
        public bool AdminOnly { get; set; }

        /// <summary>
        /// Timestamp when this tag was created
        /// </summary>
        public int CreatedAt { get; set; }

        /// <summary>
        /// ID of the admin who created this tag
        /// </summary>
        public string? CreatedById { get; set; }

        [JsonIgnore]
        public Player? CreatedBy { get; set; }

        /// <summary>
        /// Tag assignments linking this tag to tasks
        /// </summary>
        [JsonIgnore]
        public ICollection<WorkTaskTagAssignment>? Assignments { get; set; }
    }
}
