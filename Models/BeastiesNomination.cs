using System.ComponentModel.DataAnnotations;

namespace BeatLeader_Server.Models {
    public class BeastiesNomination {
        public int Id { get; set; }

        [StringLength(25, MinimumLength = 0)]
        public string PlayerId { get; set; }
        [StringLength(25, MinimumLength = 0)]
        public string LeaderboardId { get; set; }
        [StringLength(50, MinimumLength = 0)]
        public string Category { get; set; }
        public int Timepost { get; set; }
    }
}
