namespace BeatLeader.Models.SongSuggest;

public class SongSuggestSong {
    public string ID { get; set; } = null!;
    public string name { get; set; } = null!;
    public string hash { get; set; } = null!;
    public string difficulty { get; set; } = null!;
    public string mode { get; set; } = null!;
    public float stars { get; set; }
}