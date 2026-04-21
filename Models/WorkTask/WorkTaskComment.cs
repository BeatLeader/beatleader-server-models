using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models
{
    /// <summary>
    /// Represents a comment on a work task
    /// </summary>
    [Index(nameof(WorkTaskId), IsUnique = false)]
    [Index(nameof(AuthorId), IsUnique = false)]
    public class WorkTaskComment : TrackedEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// The work task this comment belongs to
        /// </summary>
        public int WorkTaskId { get; set; }

        [JsonIgnore]
        public WorkTask? WorkTask { get; set; }

        /// <summary>
        /// Comment content (supports markdown/rich text)
        /// </summary>
        public string Content { get; set; } = "";

        /// <summary>
        /// ID of the player who wrote this comment
        /// </summary>
        public string? AuthorId { get; set; }

        public Player? Author { get; set; }

        /// <summary>
        /// Timestamp when the comment was created
        /// </summary>
        public int CreatedAt { get; set; }

        /// <summary>
        /// Timestamp of the last edit
        /// </summary>
        public int? EditedAt { get; set; }

        /// <summary>
        /// Whether the comment has been edited
        /// </summary>
        public bool IsEdited { get; set; }

        /// <summary>
        /// Sum of all votes on this comment
        /// </summary>
        public int VoteScore { get; set; }

        /// <summary>
        /// Whether this comment has been deleted (soft delete)
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// ID of admin who deleted the comment (if deleted by admin)
        /// </summary>
        public string? DeletedById { get; set; }

        [JsonIgnore]
        public Player? DeletedBy { get; set; }

        /// <summary>
        /// Timestamp when the comment was deleted
        /// </summary>
        public int? DeletedAt { get; set; }

        /// <summary>
        /// Parent comment ID for threaded replies (null for top-level comments)
        /// </summary>
        public int? ParentCommentId { get; set; }

        [JsonIgnore]
        public WorkTaskComment? ParentComment { get; set; }

        /// <summary>
        /// Replies to this comment
        /// </summary>
        public ICollection<WorkTaskComment>? Replies { get; set; }

        /// <summary>
        /// Votes on this comment
        /// </summary>
        [JsonIgnore]
        public ICollection<WorkTaskCommentVote>? Votes { get; set; }

        /// <summary>
        /// Attachments on this comment
        /// </summary>
        public ICollection<WorkTaskCommentAttachment>? Attachments { get; set; }
    }

    /// <summary>
    /// Represents an attachment on a comment
    /// </summary>
    public class WorkTaskCommentAttachment : TrackedEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// The comment this attachment belongs to
        /// </summary>
        public int CommentId { get; set; }

        [JsonIgnore]
        public WorkTaskComment? Comment { get; set; }

        /// <summary>
        /// Type of the attachment
        /// </summary>
        public WorkTaskAttachmentType Type { get; set; }

        /// <summary>
        /// Original file name
        /// </summary>
        [StringLength(255)]
        public string FileName { get; set; } = "";

        /// <summary>
        /// URL where the file is stored
        /// </summary>
        public string Url { get; set; } = "";

        /// <summary>
        /// Timestamp when the file was uploaded
        /// </summary>
        public int UploadedAt { get; set; }
    }
}
