using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatLeader_Server.Models
{
    public class GlobalMapHistory : TrackedEntity
    {
        public int Id { get; set; }
        public int Timestamp { get; set; }
        public int ClanId { get; set; }
        public Clan Clan { get; set; }
        public float GlobalMapCaptured { get; set; }
        public int PlayersCount { get; set; }
        public int MainPlayersCount { get; set; }
        public float Pp { get; set; }
        public int Rank { get; set; }
        public float AverageRank { get; set; }
        public float AverageAccuracy { get; set; }
        public int CaptureLeaderboardsCount { get; set; }
    }
}
