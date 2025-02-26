using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatLeader_Server.Models
{
    [Flags]
    public enum InfoToHighlight
    {
        None = 0,
        WatchCount = 1 << 1,
        PlayCount = 1 << 2,
    }

    public class ScoreMetadata 
    {
        public int Id { get; set; }
        public LeaderboardContexts PinnedContexts { get; set; }
        public InfoToHighlight HighlightedInfo { get; set; } = InfoToHighlight.WatchCount;
        public int Priority { get; set; }
        public string? Description { get; set; }

        public string? LinkService { get; set; }
        public string? LinkServiceIcon { get; set; }
        public string? Link { get; set; }
    }
}
