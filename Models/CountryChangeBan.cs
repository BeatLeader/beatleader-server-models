namespace BeatLeader.Models;

public class CountryChangeBan {
    public int Id { get; set; }
    public required string PlayerId { get; set; }
    public int Timeset { get; set; }
}