using Newtonsoft.Json;

namespace BeatLeader.Models;

public class GraphResponse {
    public required string LeaderboardId { get; set; }
    public required string Diff { get; set; }
    public required string Mode { get; set; }
    public required string Modifiers { get; set; }
    public required string SongName { get; set; }
    public required string Hash { get; set; }
    public required string Mapper { get; set; }
    public float Acc { get; set; }
    public required string Timeset { get; set; }
    public float? Stars { get; set; }

    [JsonIgnore]
    public ModifiersRating? ModifiersRating { get; set; }
    [JsonIgnore]
    public ModifiersMap? ModifierValues { get; set; }
    [JsonIgnore]
    public float? PassRating { get; set; }
    [JsonIgnore]
    public float? AccRating { get; set; }
    [JsonIgnore]
    public float? TechRating { get; set; }
}