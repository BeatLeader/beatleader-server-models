namespace BeatLeader.Models;

public class VoterFeedback {
    public int Id { get; set; }
    public string RTMember { get; set; } = null!;
    public float Value { get; set; }
}