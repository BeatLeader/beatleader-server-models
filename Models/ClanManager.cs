using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatLeader_Server.Models
{
    [Flags]
    public enum ClanPermissions
    {
        None = 0,
        Edit = 1 << 1,
        Invite = 1 << 2,
        Kick = 1 << 3,
    }

    public class ClanManager
    {
        public int Id { get; set; }
        public int? ClanId { get; set; }
        public Clan? Clan { get; set; }
        public string? PlayerId { get; set; }
        public Player? Player { get; set; }
        public ClanPermissions Permissions { get; set; }
    }
}
