using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models
{
    /// <summary>
    /// Represents a vote on a work task (upvote/downvote)
    /// </summary>
    [Index(nameof(WorkTaskId), nameof(PlayerId), IsUnique = true)]
    public class WorkTaskVote : TrackedEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// The work task being voted on
        /// </summary>
        public int WorkTaskId { get; set; }

        [JsonIgnore]
        public WorkTask? WorkTask { get; set; }

        /// <summary>
        /// ID of the player who voted
        /// </summary>
        public string PlayerId { get; set; } = "";

        [JsonIgnore]
        public Player? Player { get; set; }

        /// <summary>
        /// Vote value: +1 for upvote, -1 for downvote
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Timestamp when the vote was cast
        /// </summary>
        public int VotedAt { get; set; }

        /// <summary>
        /// Whether this vote was removed by an admin
        /// </summary>
        public bool IsRemoved { get; set; }

        /// <summary>
        /// ID of admin who removed the vote (if removed)
        /// </summary>
        public string? RemovedById { get; set; }

        [JsonIgnore]
        public Player? RemovedBy { get; set; }

        /// <summary>
        /// Timestamp when the vote was removed
        /// </summary>
        public int? RemovedAt { get; set; }

        /// <summary>
        /// Reason for removal (optional)
        /// </summary>
        public string? RemovalReason { get; set; }
    }
}
