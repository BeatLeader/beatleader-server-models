namespace BeatLeader.Models.SongSuggest;

public class Top10kPlayer {
    public string id { get; set; } = null!;
    public string name { get; set; } = null!;
    public int rank { get; set; }

    public List<Top10kScore> top10kScore { get; set; } = null!;
}