namespace BeatLeader.Models {
    public class BeatSaverLink {
        public string Id { get; set; }
        public string BeatSaverId { get; set; }
        public string Token { get; set; } = "";
        public string RefreshToken { get; set; } = "";
        public string Timestamp { get; set; } = "";
    }
}