using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatLeader_Server.Models
{
    public class ScoreExternalStatus 
    {
        public int Id { get; set; }
        public ScoreStatus Status { get; set; }
        public int Timestamp { get; set; }

        public string? LinkService { get; set; }
        public string? LinkServiceIcon { get; set; }
        public string? Link { get; set; }
    }
}
