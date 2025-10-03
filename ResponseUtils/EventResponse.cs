using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BeatLeader_Server.Utils.ResponseUtils;

namespace BeatLeader_Server.Utils {

    public class MapOTDEventStatus {
    
        public EventResponse EventDescription { get; set; } 
        public MapOTDDayStatus? today { get; set; }
        public MapOTDDayStatus[] previousDays { get; set; }
    }

    public class EarnedPoints {
        public int Points { get; set; }
        public int Rank { get; set; }
    }

    public class MapOTDDayStatus {
        public SongResponse song { get; set; }
        public ScoreResponseWithAcc? score { get; set; }
        public int day { get; set; }
        public int startTime { get; set; }
        public int endTime { get; set; }
        public EarnedPoints? Points { get; set; }
    }
}
