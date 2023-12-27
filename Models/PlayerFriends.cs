﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BeatLeader.Models {
    public class PlayerFriends {
        public string Id { get; set; }

        [ForeignKey("PlayerFriendsId")]
        public ICollection<Player> Friends { get; set; } = new List<Player>();
    }
}