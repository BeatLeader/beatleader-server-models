using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models
{
    /// <summary>
    /// Type of attachment
    /// </summary>
    public enum WorkTaskAttachmentType
    {
        File = 0,
        Image = 1,
        Video = 2,
        Link = 3
    }

    /// <summary>
    /// Represents a file or image attachment on a work task
    /// </summary>
    public class WorkTaskAttachment : TrackedEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// The work task this attachment belongs to
        /// </summary>
        public int WorkTaskId { get; set; }

        [JsonIgnore]
        public WorkTask? WorkTask { get; set; }

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
        /// MIME type of the file
        /// </summary>
        [StringLength(100)]
        public string? MimeType { get; set; }

        /// <summary>
        /// File size in bytes
        /// </summary>
        public long? FileSize { get; set; }

        /// <summary>
        /// ID of the player who uploaded this attachment
        /// </summary>
        public string? UploadedById { get; set; }

        [JsonIgnore]
        public Player? UploadedBy { get; set; }

        /// <summary>
        /// Timestamp when the file was uploaded
        /// </summary>
        public int UploadedAt { get; set; }
    }
}
