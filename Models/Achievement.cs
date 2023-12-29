namespace BeatLeader.Models;

public class AchievementLevel {
    public int Id { get; set; }

    public required string Image { get; set; }
    public required string SmallImage { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? DetailedDescription { get; set; }
    public string? Color { get; set; }
    public float? Value { get; set; }
    public int Level { get; set; }
    public int AchievementDescriptionId { get; set; }
}

public class AchievementDescription {
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public string? Link { get; set; }

    public ICollection<Achievement>? Achievements { get; set; }
    public ICollection<AchievementLevel>? Levels { get; set; }
}

public class Achievement {
    public int Id { get; set; }
    public required string PlayerId { get; set; }
    public required Player Player { get; set; }
    public int AchievementDescriptionId { get; set; }
    public required AchievementDescription AchievementDescription { get; set; }

    public AchievementLevel? Level { get; set; }
    public int Timeset { get; set; }
    public int Count { get; set; }
}