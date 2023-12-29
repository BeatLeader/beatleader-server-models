using System.Diagnostics.CodeAnalysis;

namespace BeatLeader.Models;

[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
public class MapDetail {
    public string? Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required UserDetail Uploader { get; set; }
    public required MapDetailMetadata Metadata { get; set; }
    public DateTime? Uploaded { get; set; }
    public bool Automapper { get; set; }
    public bool Ranked { get; set; }
    public bool Qualified { get; set; }
    public required List<MapVersion> Versions { get; set; }
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
    public required List<MapDetail> Docs { get; set; }
}

public class UserDetail {
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool UniqueSet { get; set; }
    public string? Hash { get; set; }
    public bool? Testplay { get; set; }
    public required string Avatar { get; set; }
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
    public required string Hash { get; set; }
    public string? Key { get; set; }
    public required string State { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public short? SageScore { get; set; }
    public required List<MapDifficulty> Diffs { get; set; }
    public string? Feedback { get; set; }
    public required string DownloadURL { get; set; }
    public required string CoverURL { get; set; }
    public required string PreviewURL { get; set; }
}

public class MapDifficulty {
    public float Njs { get; set; }
    public float Offset { get; set; }
    public int Notes { get; set; }
    public int Bombs { get; set; }
    public int Obstacles { get; set; }
    public float Nps { get; set; }
    public double Length { get; set; }
    public required string Characteristic { get; set; }
    public required string Difficulty { get; set; }
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
    public required string SongName { get; set; }
    public required string SongSubName { get; set; }
    public required string SongAuthorName { get; set; }
    public required string LevelAuthorName { get; set; }
}