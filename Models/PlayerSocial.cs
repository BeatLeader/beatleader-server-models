using System.ComponentModel.DataAnnotations;

namespace BeatLeader_Server.Models
{
    public class PlayerSocial
    {
        public int Id { get; set; }
        [StringLength(40, MinimumLength = 0)]
        public string Service { get; set; }
        public string Link { get; set; }
        public string User { get; set; }

        [StringLength(40, MinimumLength = 0)]
        public string UserId { get; set; }
        public string? PlayerId { get; set; }
        public bool Hidden { get; set; }
    }
}
