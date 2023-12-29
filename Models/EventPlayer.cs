namespace BeatLeader.Models;

public class EventPlayer {
    public int Id { get; set; }
    public int EventId { get; set; }
    public required string Name { get; set; }
    public required string PlayerId { get; set; }
    public required string Country { get; set; }
    public int Rank { get; set; }
    public int CountryRank { get; set; }
    public float Pp { get; set; }
}