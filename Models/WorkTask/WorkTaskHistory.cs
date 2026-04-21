using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models
{
    /// <summary>
    /// Type of change recorded in history
    /// </summary>
    public enum WorkTaskHistoryAction
    {
        Created = 0,
        TitleChanged = 1,
        DescriptionChanged = 2,
        StatusChanged = 3,
        PriorityChanged = 4,
        TagAdded = 5,
        TagRemoved = 6,
        AssigneeAdded = 7,
        AssigneeRemoved = 8,
        AttachmentAdded = 9,
        AttachmentRemoved = 10,
        CommentAdded = 11,
        CommentEdited = 12,
        CommentDeleted = 13,
        VoteAdded = 14,
        VoteRemoved = 15,
        TaskLocked = 16,
        TaskUnlocked = 17,
        TaskArchived = 18,
        TaskUnarchived = 19,
        DueDateChanged = 20,
        Resolved = 21,
        Reopened = 22,
        VisibilityChanged = 23
    }

    /// <summary>
    /// Represents a historical change to a work task for audit trail
    /// </summary>
    [Index(nameof(WorkTaskId), IsUnique = false)]
    [Index(nameof(Timestamp), IsUnique = false)]
    [Index(nameof(PlayerId), IsUnique = false)]
    public class WorkTaskHistory : TrackedEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// The work task this history entry belongs to
        /// </summary>
        public int WorkTaskId { get; set; }

        [JsonIgnore]
        public WorkTask? WorkTask { get; set; }

        /// <summary>
        /// Type of action that was performed
        /// </summary>
        public WorkTaskHistoryAction Action { get; set; }

        /// <summary>
        /// ID of the player who made the change
        /// </summary>
        public string? PlayerId { get; set; }

        public Player? Player { get; set; }

        /// <summary>
        /// Timestamp when the change was made
        /// </summary>
        public int Timestamp { get; set; }

        /// <summary>
        /// Name of the field that was changed (for field changes)
        /// </summary>
        [StringLength(100)]
        public string? FieldName { get; set; }

        /// <summary>
        /// Previous value (serialized as string)
        /// </summary>
        public string? OldValue { get; set; }

        /// <summary>
        /// New value (serialized as string)
        /// </summary>
        public string? NewValue { get; set; }

        /// <summary>
        /// Additional details/context about the change
        /// </summary>
        public string? Details { get; set; }

        /// <summary>
        /// Related entity ID (e.g., comment ID for comment actions, tag ID for tag actions)
        /// </summary>
        public int? RelatedEntityId { get; set; }

        /// <summary>
        /// Type of related entity
        /// </summary>
        [StringLength(50)]
        public string? RelatedEntityType { get; set; }
    }
}
