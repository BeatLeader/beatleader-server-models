using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatLeader_Server.Models {
    public class Speedrun {
        public int Id { get; set; }
        public string PlayerId { get; set; }
        public float Pp { get; set; }
        public bool Record { get; set; }
        public int FinishTimeset { get; set; }
    }
}
