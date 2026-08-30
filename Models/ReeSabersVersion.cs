using System.ComponentModel.DataAnnotations;

namespace BeatLeader_Server.Models {
    public class ReeSabersVersion {
        public int Id { get; set; }
        public int Timeset { get; set; }
        [StringLength(50, MinimumLength = 0)]
        public string Version { get; set; }
        [StringLength(50, MinimumLength = 0)]
        public string MoreInfoLink { get; set; }
        [StringLength(50, MinimumLength = 0)]
        public string DownloadLink { get; set; }
        public string Message { get; set; }
    }
}
