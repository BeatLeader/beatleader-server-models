namespace BeatLeader.Models.SongSuggest;

public class Top10kPlayer {
    public required string id { get; set; }
    public required string name { get; set; }
    public int rank { get; set; }

    public List<Top10kScore> top10kScore { get; set; } = new();
}