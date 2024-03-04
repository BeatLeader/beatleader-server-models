﻿namespace BeatLeader_Server.Models
{
    public class EventPlayer
    {
        public int Id { get; set; }
        public int? EventRankingId { get; set; }
        public EventRanking Event { get; set; }

        public string EventName { get; set; }
        public string PlayerName { get; set; }

        public string PlayerId { get; set; }
        public Player Player { get; set; }
        public string Country { get; set; }
        public int Rank { get; set; }
        public int CountryRank { get; set; }
        public float Pp { get; set; }
    }
}
