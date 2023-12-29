namespace BeatLeader.Models;

public class SurveyPassed {
    public int Id { get; set; }
    public required string PlayerId { get; set; }
    public required string SurveyId { get; set; }
    public int Timeset { get; set; }
}