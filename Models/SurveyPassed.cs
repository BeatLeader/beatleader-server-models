namespace BeatLeader.Models;

public class SurveyPassed {
    public int Id { get; set; }
    public string PlayerId { get; set; } = null!;
    public string SurveyId { get; set; } = null!;
    public int Timeset { get; set; }
}