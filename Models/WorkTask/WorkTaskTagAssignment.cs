using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models
{
    /// <summary>
    /// Represents the assignment of a tag to a work task
    /// </summary>
    public class WorkTaskTagAssignment : TrackedEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// The work task this tag is assigned to
        /// </summary>
        public int WorkTaskId { get; set; }

        [JsonIgnore]
        public WorkTask? WorkTask { get; set; }

        /// <summary>
        /// The tag assigned to the task
        /// </summary>
        public int TagId { get; set; }

        public WorkTaskTag? Tag { get; set; }

        /// <summary>
        /// ID of the player who added this tag
        /// </summary>
        public string? AddedById { get; set; }

        [JsonIgnore]
        public Player? AddedBy { get; set; }

        /// <summary>
        /// Timestamp when the tag was added
        /// </summary>
        public int AddedAt { get; set; }
    }
}
