using System.Diagnostics.CodeAnalysis;

namespace BeatLeader.Models;

[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
public class MapDetail {
    public string? Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public UserDetail Uploader { get; set; } = null!;
    public MapDetailMetadata Metadata { get; set; } = null!;
    public DateTime? Uploaded { get; set; }
    public bool Automapper { get; set; }
    public bool Ranked { get; set; }
    public bool Qualified { get; set; }
    public List<MapVersion> Versions { get; set; } = null!;
    public UserDetail? Curator { get; set; }
    public DateTime? CuratedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? LastPublishedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public List<string>? Tags { get; set; }
    public bool? Bookmarked { get; set; }
    public List<UserDetail>? Collaborators { get; set; }
}

public class SearchResponse {
    public List<MapDetail> Docs { get; set; } = null!;
}

public class UserDetail {
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool UniqueSet { get; set; }
    public string? Hash { get; set; }
    public bool? Testplay { get; set; }
    public string Avatar { get; set; } = null!;
    public string? Email { get; set; }
    public int? UploadLimit { get; set; }
    public bool? Admin { get; set; }
    public bool? Curator { get; set; }
    public bool CuratorTab { get; set; }
    public bool VerifiedMapper { get; set; }
    public DateTimeOffset? SuspendedAt { get; set; }
    public string? PlaylistUrl { get; set; }
}

public class MapVersion {
    public string Hash { get; set; } = null!;
    public string? Key { get; set; }
    public string State { get; set; } = null!;
    public DateTimeOffset CreatedAt { get; set; }
    public short? SageScore { get; set; }
    public List<MapDifficulty> Diffs { get; set; } = null!;
    public string? Feedback { get; set; }
    public string DownloadURL { get; set; } = null!;
    public string CoverURL { get; set; } = null!;
    public string PreviewURL { get; set; } = null!;
}

public class MapDifficulty {
    public float Njs { get; set; }
    public float Offset { get; set; }
    public int Notes { get; set; }
    public int Bombs { get; set; }
    public int Obstacles { get; set; }
    public float Nps { get; set; }
    public double Length { get; set; }
    public string Characteristic { get; set; } = null!;
    public string Difficulty { get; set; } = null!;
    public int Events { get; set; }
    public bool Chroma { get; set; }
    public bool Me { get; set; }
    public bool Ne { get; set; }
    public bool Cinema { get; set; }
    public double Seconds { get; set; }
    public float? Stars { get; set; }
    public int MaxScore { get; set; }
    public string? Label { get; set; }
}

public class MapDetailMetadata {
    public float Bpm { get; set; }
    public int Duration { get; set; }
    public string SongName { get; set; } = null!;
    public string SongSubName { get; set; } = null!;
    public string SongAuthorName { get; set; } = null!;
    public string LevelAuthorName { get; set; } = null!;
}