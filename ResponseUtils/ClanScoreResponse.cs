using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatLeader_Server.Utils
{
    public class ClanScoreResponse
    {
        public int Id { get; set; }
        public int ModifiedScore { get; set; }
        public float Accuracy { get; set; }
        public int ClanId { get; set; }
        public float Pp { get; set; }
        public int Rank { get; set; }
        
        public string LeaderboardId { get; set; }
        public string Timepost { get; set; }
        public ClanScoreClanResponse? Clan { get; set; }
        
    }

    public class ClanScoreClanResponse {
        public int Id { get; set; }
        public string Tag { get; set; } = "";
        public string Color { get; set; } = "";

        public string Name { get; set; } = "";
        public string Avatar { get; set; } = "";

        public float Pp { get; set; }
        public int Rank { get; set; }
            
    }
}
