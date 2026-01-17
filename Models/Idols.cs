using static BeatLeader_Server.Utils.ResponseUtils;

namespace BeatLeader_Server.Models {

    // Database entity for an idol decoration (hearts, stars, etc.)
    public class IdolDecoration {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool GloballyAvailable { get; set; } // Available to all players

        public string SmallPictureRegular { get; set; }
        public string BigPictureRegular { get; set; }
        public string SmallPicturePro { get; set; }
        public string BigPicturePro { get; set; }
        public string Description { get; set; }
        public string? SongId { get; set; }
        public Song? Song { get; set; }
    }

    // Database entity for an idol description
    public class IdolDescription {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Bonus { get; set; }
        public bool GloballyAvailable { get; set; } // Available to all players as bonus
        public int Birthday { get; set; }

        public string SmallPictureRegular { get; set; }
        public string BigPictureRegular { get; set; }
        public string SmallPicturePro { get; set; }
        public string BigPicturePro { get; set; }
        public string Description { get; set; }
        public string? RewardGif { get; set; }
    }

    // Database entity for canvas background options
    public class IdolBackground {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool GloballyAvailable { get; set; } // Available to all players
        public string ImageUrl { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? Description { get; set; }
    }

    // Database entity for a player's canvas state (saved sticker arrangement)
    public class IdolCanvas {
        public int Id { get; set; }
        public string? PlayerId { get; set; }
        public Player? Player { get; set; }
        public string CanvasState { get; set; } // JSON serialized sticker positions
        public int BackgroundId { get; set; }
        public string? SeenIdolIds { get; set; } // JSON array of idol IDs the player has seen (for "new" indicator)
        public int LastUpdated { get; set; }
    }

    // Database entity for bonus idols awarded to players
    public class PlayerBonusIdol {
        public int Id { get; set; }
        public string? PlayerId { get; set; }
        public Player? Player { get; set; }
        public int IdolDescriptionId { get; set; }
        public IdolDescription IdolDescription { get; set; }
        public string Reason { get; set; }
    }

    // Database entity for decorations awarded to players
    public class PlayerIdolDecoration {
        public int Id { get; set; }
        public string? PlayerId { get; set; }
        public Player? Player { get; set; }
        public int IdolDecorationId { get; set; }
        public IdolDecoration IdolDecoration { get; set; }
        public string Reason { get; set; }
    }
}
