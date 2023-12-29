namespace BeatLeader.Models;

public class EventRanking {
    public int Id { get; set; }
    public required string Name { get; set; }
    public int EndDate { get; set; }
    public int PlaylistId { get; set; }
    public required string Image { get; set; }

    public required ICollection<Leaderboard> Leaderboards { get; set; }
    public required ICollection<EventPlayer> Players { get; set; }
}