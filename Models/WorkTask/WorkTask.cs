using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models
{
    /// <summary>
    /// Base work task model representing a trackable work item.
    /// Can be a generic task, bug report, suggestion, or help request.
    /// </summary>
    [Index(nameof(Type), IsUnique = false)]
    [Index(nameof(StatusId), IsUnique = false)]
    [Index(nameof(CreatedAt), IsUnique = false)]
    [Index(nameof(CreatorId), IsUnique = false)]
    public class WorkTask : TrackedEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// Type of the work task (Task, BugReport, Suggestion, HelpRequest)
        /// </summary>
        public WorkTaskType Type { get; set; } = WorkTaskType.Task;

        [StringLength(200, MinimumLength = 1)]
        public string Title { get; set; } = "";

        /// <summary>
        /// Detailed description of the task (supports markdown/rich text)
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// ID of the player who created this task
        /// </summary>
        public string? CreatorId { get; set; }

        [JsonIgnore]
        public Player? Creator { get; set; }

        /// <summary>
        /// Timestamp when the task was created
        /// </summary>
        public int CreatedAt { get; set; }

        /// <summary>
        /// Timestamp of the last edit
        /// </summary>
        public int? LastEditedAt { get; set; }

        /// <summary>
        /// ID of the player who last edited this task
        /// </summary>
        public string? LastEditedById { get; set; }

        [JsonIgnore]
        public Player? LastEditedBy { get; set; }

        /// <summary>
        /// Current status of the task
        /// </summary>
        public int? StatusId { get; set; }

        public WorkTaskStatus? Status { get; set; }

        /// <summary>
        /// Priority level (1 = highest, 5 = lowest)
        /// </summary>
        public int Priority { get; set; } = 3;

        /// <summary>
        /// Sum of all votes (positive = upvotes - downvotes)
        /// </summary>
        public int VoteScore { get; set; }

        /// <summary>
        /// Count of comments on this task
        /// </summary>
        public int CommentCount { get; set; }

        /// <summary>
        /// Whether the task is visible to all players or only admins
        /// </summary>
        public bool IsPublic { get; set; } = true;

        /// <summary>
        /// Whether the task is archived (hidden from default views)
        /// </summary>
        public bool IsArchived { get; set; }

        /// <summary>
        /// Whether the task is locked (no new comments/votes from non-admins)
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// Optional due date (Unix timestamp)
        /// </summary>
        public int? DueDate { get; set; }

        /// <summary>
        /// Timestamp when the task was resolved/closed
        /// </summary>
        public int? ResolvedAt { get; set; }

        /// <summary>
        /// ID of the player who resolved/closed the task
        /// </summary>
        public string? ResolvedById { get; set; }

        [JsonIgnore]
        public Player? ResolvedBy { get; set; }

        /// <summary>
        /// Files and images attached to this task
        /// </summary>
        public ICollection<WorkTaskAttachment>? Attachments { get; set; }

        /// <summary>
        /// Comments on this task
        /// </summary>
        public ICollection<WorkTaskComment>? Comments { get; set; }

        /// <summary>
        /// Votes on this task
        /// </summary>
        [JsonIgnore]
        public ICollection<WorkTaskVote>? Votes { get; set; }

        /// <summary>
        /// Tags assigned to this task
        /// </summary>
        public ICollection<WorkTaskTagAssignment>? TagAssignments { get; set; }

        /// <summary>
        /// Players assigned to work on this task
        /// </summary>
        public ICollection<WorkTaskAssignment>? Assignments { get; set; }

        /// <summary>
        /// History of changes made to this task
        /// </summary>
        [JsonIgnore]
        public ICollection<WorkTaskHistory>? History { get; set; }
    }
}
