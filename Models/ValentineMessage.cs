using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatLeader_Server.Models
{
    public class ValentineMessage
    {
        public int Id { get; set; }
        public string? SenderId { get; set; }
        public string? ReceiverId { get; set; }

        public string Message { get; set; }
        public int Timeset { get; set; }
        public bool Viewed { get; set; }

        public int ViewCount { get; set; }
    }
}
