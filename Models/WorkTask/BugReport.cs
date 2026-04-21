using System.ComponentModel.DataAnnotations;

namespace BeatLeader_Server.Models
{
    /// <summary>
    /// Severity level for bug reports
    /// </summary>
    public enum BugSeverity
    {
        Low = 0,
        Medium = 1,
        High = 2,
        Critical = 3
    }

    /// <summary>
    /// Represents a bug report work task with bug-specific properties
    /// </summary>
    public class BugReport : WorkTask
    {
        public BugReport()
        {
            Type = WorkTaskType.BugReport;
        }

        /// <summary>
        /// Severity of the bug
        /// </summary>
        public BugSeverity Severity { get; set; } = BugSeverity.Medium;

        /// <summary>
        /// Steps to reproduce the bug
        /// </summary>
        public string? StepsToReproduce { get; set; }

        /// <summary>
        /// Expected behavior
        /// </summary>
        public string? ExpectedBehavior { get; set; }

        /// <summary>
        /// Actual behavior observed
        /// </summary>
        public string? ActualBehavior { get; set; }

        /// <summary>
        /// Game/mod version where the bug was found
        /// </summary>
        [StringLength(50)]
        public string? Version { get; set; }

        /// <summary>
        /// Platform (PC VR, Quest, etc.)
        /// </summary>
        [StringLength(50)]
        public string? Platform { get; set; }

        /// <summary>
        /// Whether the bug is reproducible
        /// </summary>
        public bool? IsReproducible { get; set; }

        /// <summary>
        /// Log file content or reference
        /// </summary>
        public string? LogContent { get; set; }
    }
}
