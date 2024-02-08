﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BeatLeader_Server.Models
{
    public class Clan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public string Tag { get; set; }
        public string LeaderID { get; set; }
        public string Description { get; set; }
        public string Bio { get; set; }
        public int PlayersCount { get; set; }
        public float Pp { get; set; }
        public int Rank { get; set; }
        public float AverageRank { get; set; }
        public float AverageAccuracy { get; set; }
        public ICollection<FeaturedPlaylist>? FeaturedPlaylists { get; set; }

        public ICollection<Player> Players { get; set; } = new List<Player>();

        [InverseProperty("ClanRequest")]
        public ICollection<User> Requests { get; set; } = new List<User>();

        [InverseProperty("BannedClans")]
        public ICollection<User> Banned { get; set; } = new List<User>();
        
        public float RankedPoolPercentCaptured { get; set; }
        public int CaptureLeaderboardsCount { get; set; }
        public ICollection<Leaderboard>? CapturedLeaderboards { get; set; }

        public float GlobalMapX { get; set; }
        public float GlobalMapY { get; set; }

        public ICollection<GlobalMapHistory> History { get; set; }

        public string? PlayerChangesCallback { get; set; }
        public string? ClanRankingDiscordHook { get; set; }
    }

    public class ReservedClanTag
    {
        public int Id { get; set; }
        public string Tag { get; set; }
    }
}
