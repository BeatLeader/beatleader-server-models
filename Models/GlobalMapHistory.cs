using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatLeader_Server.Models
{
    public class GlobalMapHistory
    {
        public int Id { get; set; }
        public int Timestamp { get; set; }
        public int ClanId { get; set; }
        public Clan Clan { get; set; }
        public float GlobalMapCaptured { get; set; }
    }
}
