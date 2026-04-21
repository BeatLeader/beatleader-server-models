using System.ComponentModel.DataAnnotations;

namespace BeatLeader_Server.Models
{
    /// <summary>
    /// Category of suggestion
    /// </summary>
    public enum SuggestionCategory
    {
        Feature = 0,
        Improvement = 1,
        UX = 2,
        Performance = 3,
        Accessibility = 4,
        Other = 5
    }

    /// <summary>
    /// Represents a suggestion/feature request work task
    /// </summary>
    public class Suggestion : WorkTask
    {
        public Suggestion()
        {
            Type = WorkTaskType.Suggestion;
        }

        /// <summary>
        /// Category of the suggestion
        /// </summary>
        public SuggestionCategory Category { get; set; } = SuggestionCategory.Feature;

        /// <summary>
        /// Use case or problem this suggestion addresses
        /// </summary>
        public string? UseCase { get; set; }

        /// <summary>
        /// Proposed solution/implementation
        /// </summary>
        public string? ProposedSolution { get; set; }

        /// <summary>
        /// Alternative solutions considered
        /// </summary>
        public string? Alternatives { get; set; }

        /// <summary>
        /// Estimated impact if implemented (Low, Medium, High)
        /// </summary>
        [StringLength(20)]
        public string? Impact { get; set; }

        /// <summary>
        /// Target area of the mod/system (e.g., "Leaderboards", "Replays", "UI")
        /// </summary>
        [StringLength(100)]
        public string? TargetArea { get; set; }
    }
}
