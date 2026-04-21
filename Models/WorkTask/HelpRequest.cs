using System.ComponentModel.DataAnnotations;

namespace BeatLeader_Server.Models
{
    /// <summary>
    /// Category of help request
    /// </summary>
    public enum HelpCategory
    {
        Installation = 0,
        Configuration = 1,
        Usage = 2,
        Account = 3,
        Technical = 4,
        Other = 5
    }

    /// <summary>
    /// Urgency level for help requests
    /// </summary>
    public enum HelpUrgency
    {
        Low = 0,
        Normal = 1,
        High = 2,
        Urgent = 3
    }

    /// <summary>
    /// Represents a help request work task
    /// </summary>
    public class HelpRequest : WorkTask
    {
        public HelpRequest()
        {
            Type = WorkTaskType.HelpRequest;
        }

        /// <summary>
        /// Category of help needed
        /// </summary>
        public HelpCategory Category { get; set; } = HelpCategory.Other;

        /// <summary>
        /// Urgency of the request
        /// </summary>
        public HelpUrgency Urgency { get; set; } = HelpUrgency.Normal;

        /// <summary>
        /// What the user has already tried
        /// </summary>
        public string? AlreadyTried { get; set; }

        /// <summary>
        /// Error message if any
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Game/mod version
        /// </summary>
        [StringLength(50)]
        public string? Version { get; set; }

        /// <summary>
        /// Platform (PC VR, Quest, etc.)
        /// </summary>
        [StringLength(50)]
        public string? Platform { get; set; }

        /// <summary>
        /// Resolution provided (for completed help requests)
        /// </summary>
        public string? Resolution { get; set; }

        /// <summary>
        /// Whether the user marked this as resolved
        /// </summary>
        public bool IsResolved { get; set; }

        /// <summary>
        /// Timestamp when user marked as resolved
        /// </summary>
        public int? UserResolvedAt { get; set; }
    }
}
