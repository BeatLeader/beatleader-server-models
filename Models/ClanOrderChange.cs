using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatLeader_Server.Models
{
    public class ClanOrderChange
    {
        public int Id { get; set; }
        public int Timestamp { get; set; }
        public string PlayerId { get; set; }
        public string OldOrder { get; set; }
        public string NewOrder { get; set; }
    }
}
