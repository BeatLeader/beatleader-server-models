namespace BeatLeader.Models.SongSuggest;

public class SongSuggestSong {
    public required string ID { get; set; }
    public required string name { get; set; }
    public required string hash { get; set; }
    public required string difficulty { get; set; }
    public required string mode { get; set; }
    public required float stars { get; set; }
}