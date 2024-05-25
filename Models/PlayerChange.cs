namespace BeatLeader_Server.Models {
    public class PlayerChange {
        public int Id { get; set; }
        public int Timestamp { get; set; }
        public string? PlayerId { get; set; }

        public string? OldName { get; set; }
        public string? NewName { get; set; }

        public string? OldCountry { get; set; }
        public string? NewCountry { get; set; }

        public string? Changer { get; set; }
    }
}
