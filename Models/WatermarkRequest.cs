using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatLeader_Server.Models {
    public enum WatermarkRequestStatus
    {
        unknown = 0,
        open = 1,
        approved = 2,
        declined = 3
    }

    public class WatermarkRequest {
        public int Id { get; set; }
        public int Timeset { get; set; }
        public WatermarkRequestStatus Status { get; set; }
        public string PlayerId { get; set; }
        public string Reason { get; set; }
    }
}
