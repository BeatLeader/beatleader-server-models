namespace BeatLeader_Server.Utils {
    public class ClanTrianglePlayer {
        public string Id { get; set; }
        public string Avatar { get; set; }

        public float AccPp { get; set; }
        public float TechPp { get; set; }
        public float PassPp { get; set; }
    }

    public class ClanTriangleResponse {
        public float AccPp { get; set; }
        public float TechPp { get; set; }
        public float PassPp { get; set; }

        public ICollection<ClanTrianglePlayer> Players { get; set; }
    }
}
