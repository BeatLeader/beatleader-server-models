using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatLeader_Server.Models
{
    public enum PlayerClanAction {
        create = 0,
        dismantle = 1,
        kick = 2,
        join = 3,
        reject = 4,
        leave = 5,
        score = 6
    }

    public class GlobalMapChange
    {
        public int Id { get; set; }
        public string? LeaderboardId { get; set; }
        public int Timeset { get; set; }

        public float OldX { get; set; }
        public float OldY { get; set; }

        public int? OldClan1Id { get; set; }
        public float? OldClan1Capture { get; set; }
        public float? OldClan1Pp { get; set; }
        public int? OldClan2Id { get; set; }
        public float? OldClan2Capture { get; set; }
        public float? OldClan2Pp { get; set; }
        public int? OldClan3Id { get; set; }
        public float? OldClan3Capture { get; set; }
        public float? OldClan3Pp { get; set; }

        public float NewX { get; set; }
        public float NewY { get; set; }

        public int? NewClan1Id { get; set; }
        public float? NewClan1Capture { get; set; }
        public float? NewClan1Pp { get; set; }
        public int? NewClan2Id { get; set; }
        public float? NewClan2Capture { get; set; }
        public float? NewClan2Pp { get; set; }
        public int? NewClan3Id { get; set; }
        public float? NewClan3Capture { get; set; }
        public float? NewClan3Pp { get; set; }
        
        public string? PlayerId { get; set; }
        public PlayerClanAction? PlayerAction { get; set; }
        public int? ScoreId { get; set; }
    }
}
