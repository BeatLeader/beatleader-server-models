using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatLeader_Server.Utils {
    public class HistoryCompactResponse {
        public int Timestamp { get; set; }

        public float Pp { get; set; }
        public int Rank { get; set; }
        public int CountryRank { get; set; }

        public float AverageRankedAccuracy { get; set; }
        public float AverageUnrankedAccuracy { get; set; }
        public float AverageAccuracy { get; set; }

        public float MedianRankedAccuracy { get; set; }
        public float MedianAccuracy { get; set; }

        public int RankedPlayCount { get; set; }
        public int UnrankedPlayCount { get; set; }
        public int TotalPlayCount { get; set; }

        public int RankedImprovementsCount { get; set; }
        public int UnrankedImprovementsCount { get; set; }
        public int TotalImprovementsCount { get; set; }
    }
}
