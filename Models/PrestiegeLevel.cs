using System.ComponentModel.DataAnnotations;

namespace BeatLeader_Server.Models {
    public class PrestiegeLevel {
        [Key]
        public int Id { get; set; }

        public int Level { get; set; }
        public string BigIcon { get; set; }
        public string SmallIcon { get; set; }
    }
}
