using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatLeader_Server.Models
{
    public class ClanUpdate
    {
        public int Id { get; set; }
        public Clan? Clan { get; set; }
        public Player? Player { get; set; }
        public int Timeset { get; set; }

        public string? ChangeDescription { get; set; }
    }
}
