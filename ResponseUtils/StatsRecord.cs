namespace BeatLeader_Server.Utils {
    public class StatsNote {
        public float SpawnTime { get; set; }
        public int Score { get; set; }
        public float Accuracy { get; set; }
    }

    public class StatsGraph {
        public List<StatsNote> Notes { get; set; }
        public float FailTime { get; set; }
        public int AttemptId { get; set; }
    }

    public class StatsRecord {
        public List<StatsGraph> Scores { get; set; }
    }
}
