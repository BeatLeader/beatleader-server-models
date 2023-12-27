using Newtonsoft.Json;

namespace BeatLeader.Models;

public class GraphResponse {
    public string LeaderboardId { get; set; } = null!;
    public string Diff { get; set; } = null!;
    public string Mode { get; set; } = null!;
    public string Modifiers { get; set; } = null!;
    public string SongName { get; set; } = null!;
    public string Hash { get; set; } = null!;
    public string Mapper { get; set; } = null!;
    public float Acc { get; set; }
    public string Timeset { get; set; } = null!;
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