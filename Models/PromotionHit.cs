using System.ComponentModel.DataAnnotations;

namespace BeatLeader_Server.Models {
    public class PromotionHit {
        public int Id { get; set; }
        public int Promotion { get; set; }
        public int Timeset { get; set; }
        [StringLength(50, MinimumLength = 0)]
        public string UniqueId { get; set; }
        [StringLength(50, MinimumLength = 0)]
        public string Details { get; set; }
    }
}
