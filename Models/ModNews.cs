namespace BeatLeader_Server.Models {
    public class ModNews {
        public int Id { get; set; }
        public string Owner { get; set; }
        public string OwnerIcon { get; set; }

        public int Timepost { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
    }
}
