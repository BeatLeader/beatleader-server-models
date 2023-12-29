namespace BeatLeader.Models;

public class SongSuggestRefresh {
    public int Id { get; set; }
    public int Timeset { get; set; }
    public required string File { get; set; }
    public required string SongsFile { get; set; }
}