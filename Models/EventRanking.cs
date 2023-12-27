namespace BeatLeader.Models;

public class EventRanking {
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int EndDate { get; set; }
    public int PlaylistId { get; set; }
    public string Image { get; set; } = null!;

    public ICollection<Leaderboard> Leaderboards { get; set; } = null!;
    public ICollection<EventPlayer> Players { get; set; } = null!;
}