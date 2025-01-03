using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatLeader_Server.Utils {

    public class LeaderboardStatsNote {
        public float SpawnTime { get; set; }
        public int Score { get; set; }
        public float Accuracy { get; set; }
    }

    public class LeaderboardStatsGraph {
        public List<LeaderboardStatsNote> Notes { get; set; }
        public int Rank { get; set; }
        public string PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string PlayerAvatar { get; set; }
        public string Modifiers { get; set; }
    }

    public class LeaderboardStatsRecord {
        public List<LeaderboardStatsGraph> Scores { get; set; }
    }
}
