namespace BeatLeader_Server.Models {
    public class TreeOrnament {
        public int Id { get; set; }
        public int BundleId { get; set; }
        public string Description { get; set; }
    }

    public class PlayerTreeOrnament {
        public int Id { get; set; }
        public int OrnamentId { get; set; }
        public TreeOrnament Ornament { get; set; }
        public string PlayerId { get; set; }
        public Score? Score { get; set; }
    }

    public class TreeMap {
        public int Id { get; set; }
        public int BundleId { get; set; }
        public string SongId { get; set; }
        public int Timestart { get; set; }
    }
}
