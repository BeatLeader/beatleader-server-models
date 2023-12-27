namespace BeatLeader.Models;

public class SongSuggestRefresh {
    public int Id { get; set; }
    public int Timeset { get; set; }
    public string File { get; set; } = null!;
    public string SongsFile { get; set; } = null!;
}