using System;
using System.ComponentModel.DataAnnotations;
namespace BeatLeader_Server.Models
{
    public class AccountLink
    {
        public int Id { get; set; }
        [StringLength(17, MinimumLength = 0)]
        public string SteamID { get; set; } = "";
        public int OculusID { get; set; }
        [StringLength(20, MinimumLength = 0)]
        public string PCOculusID { get; set; } = "";
    }

    public class AccountLinkRequest
    {
        public int Id { get; set; }
        public string OculusID { get; set; } = "";

        public int Random { get; set; }
        public string IP { get; set; }
    }
}

