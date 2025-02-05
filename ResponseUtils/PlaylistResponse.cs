using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatLeader_Server.Utils {
    public class PlaylistDifficulty {
        public string name { get; set; }
        public string characteristic { get; set; }
    }

    public class PlaylistSong {
        public string? hash { get; set; }
        public string? key { get; set; }
        public string? songName { get; set; }
        public string? levelAuthorName { get; set; }
        public List<PlaylistDifficulty>? difficulties { get; set; }
    }

    public class PlaylisCustomData {
        public string syncURL { get; set; }
        public string owner { get; set; }
        public string id { get; set; }
        public string hash { get; set; }
        public bool shared { get; set; }
    }

    public class PlaylistResponse {
        public List<PlaylistSong> songs { get; set; }
    }
}
