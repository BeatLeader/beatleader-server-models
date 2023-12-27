namespace BeatLeader.Models;

public class EventPlayer {
    public int Id { get; set; }
    public int EventId { get; set; }
    public string Name { get; set; } = null!;
    public string PlayerId { get; set; } = null!;
    public string Country { get; set; } = null!;
    public int Rank { get; set; }
    public int CountryRank { get; set; }
    public float Pp { get; set; }
}