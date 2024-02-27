using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatLeader_Server.Models
{
    public class FeaturedPlaylist
    {
        public int Id { get; set; }
        public string PlaylistLink { get; set; }
        public string Cover { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        public string? Owner { get; set; }
        public string? OwnerCover { get; set; }
        public string? OwnerLink { get; set; }

        public ICollection<Clan>? Clans { get; set; }
        public ICollection<Leaderboard>? Leaderboards { get; set; }
    }
}
