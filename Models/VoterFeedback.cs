namespace BeatLeader.Models;

public class VoterFeedback {
    public int Id { get; set; }
    public required string RTMember { get; set; }
    public float Value { get; set; }
}