using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatLeader_Server.Models
{
    public class ScoreNomination 
    {
        public int Id { get; set; }
        public int Timestamp { get; set; }
        public int ScoreId { get; set; }
        public string PlayerId { get; set; }

        public string? Description { get; set; }
    }
}
