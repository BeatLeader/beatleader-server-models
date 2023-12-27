namespace BeatLeader.Models;

public class CountryChangeBan {
    public int Id { get; set; }
    public string PlayerId { get; set; } = null!;
    public int Timeset { get; set; }
}