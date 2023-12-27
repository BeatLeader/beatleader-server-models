namespace BeatLeader.Models;

public class AchievementLevel {
    public int Id { get; set; }

    public string Image { get; set; } = null!;
    public string SmallImage { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? DetailedDescription { get; set; }
    public string? Color { get; set; }
    public float? Value { get; set; }
    public int Level { get; set; }
    public int AchievementDescriptionId { get; set; }
}

public class AchievementDescription {
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? Link { get; set; }

    public ICollection<Achievement>? Achievements { get; set; }
    public ICollection<AchievementLevel>? Levels { get; set; }
}

public class Achievement {
    public int Id { get; set; }
    public string PlayerId { get; set; } = null!;
    public Player Player { get; set; } = null!;
    public int AchievementDescriptionId { get; set; }
    public AchievementDescription AchievementDescription { get; set; } = null!;

    public AchievementLevel? Level { get; set; }
    public int Timeset { get; set; }
    public int Count { get; set; }
}