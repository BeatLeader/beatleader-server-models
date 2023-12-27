using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace BeatLeader.Models;

[Flags]
public enum SongStatus {
    None = 0,
    Curated = 1 << 1,
    MapOfTheWeek = 1 << 2,
    NoodleMonday = 1 << 3,
    FeaturedOnCC = 1 << 4
}

public class ExternalStatus {
    public int Id { get; set; }
    public SongStatus Status { get; set; }
    public int Timeset { get; set; }
    public string? Link { get; set; }
    public string? Responsible { get; set; }
}

[Index(nameof(Hash), IsUnique = true)]
public class Song {
    public string Id { get; set; } = null!;
    public string Hash { get; set; } = null!;
    public string Name { get; set; } = null!;
    [JsonIgnore]
    public string? Description { get; set; }
    public string? SubName { get; set; }
    public string Author { get; set; } = null!;
    public string Mapper { get; set; } = null!;
    public int MapperId { get; set; }
    public string? CollaboratorIds { get; set; }
    public string CoverImage { get; set; } = null!;
    public string? FullCoverImage { get; set; }
    public string DownloadUrl { get; set; } = null!;
    public double Bpm { get; set; }
    public double Duration { get; set; }
    public string? Tags { get; set; }

    [JsonIgnore]
    public string CreatedTime { get; set; } = "";
    public int UploadTime { get; set; }
    public ICollection<DifficultyDescription> Difficulties { get; set; } = null!;
    public ICollection<ExternalStatus>? ExternalStatuses { get; set; }

    [JsonIgnore]
    public bool Checked { get; set; }
    [JsonIgnore]
    public bool Refreshed { get; set; }

    [JsonIgnore]
    public ICollection<SongSearch> Searches { get; set; } = null!;

    public void FromMapDetails(MapDetail info) {
        Author = info.Metadata.SongAuthorName;
        Mapper = info.Metadata.LevelAuthorName;
        Name = info.Metadata.SongName;
        SubName = info.Metadata.SongSubName;
        Duration = info.Metadata.Duration;
        Bpm = info.Metadata.Bpm;
        MapperId = info.Uploader.Id;
        UploadTime = (int?)info.Uploaded?.Subtract(new DateTime(1970, 1, 1)).TotalSeconds ?? 0;

        if (info.Tags != null) {
            Tags = string.Join(",", info.Tags);
        }

        if (info.Curator != null) {
            ExternalStatuses = new List<ExternalStatus> {
                new() {
                    Status      = SongStatus.Curated,
                    Timeset     = (int?)info.CuratedAt?.Subtract(new DateTime(1970, 1, 1)).TotalSeconds ?? 0,
                    Responsible = "" + info.Curator.Id
                }
            };
        }

        if (info.Collaborators?.Count > 0) {
            CollaboratorIds = string.Join(",", info.Collaborators.Select(c => c.Id));
        }

        var currentVersion = info.Versions[0];
        CoverImage = currentVersion.CoverURL;
        DownloadUrl = currentVersion.DownloadURL;
        Hash = currentVersion.Hash;

        if (info.Id != null) {
            Id = info.Id;
        } else {
            Id = currentVersion.Key ?? "";
        }

        List<DifficultyDescription> difficulties = [];
        var diffs = currentVersion.Diffs;

        foreach (var diff in diffs) {
            var difficulty = new DifficultyDescription {
                ModeName = diff.Characteristic,
                Mode = ModeForModeName(diff.Characteristic),
                DifficultyName = diff.Difficulty,
                Value = DiffForDiffName(diff.Difficulty),
                Njs = diff.Njs,
                Notes = diff.Notes,
                Bombs = diff.Bombs,
                Nps = diff.Nps,
                Walls = diff.Obstacles,
                MaxScore = diff.MaxScore,
                Duration = info.Metadata.Duration
            };

            if (diff.Chroma) {
                difficulty.Requirements |= Requirements.Chroma;
            }

            if (diff.Me) {
                difficulty.Requirements |= Requirements.MappingExtensions;
            }

            if (diff.Ne) {
                difficulty.Requirements |= Requirements.Noodles;
            }

            if (diff.Cinema) {
                difficulty.Requirements |= Requirements.Cinema;
            }

            difficulties.Add(difficulty);
        }

        Difficulties = difficulties;
    }

    public static int ModeForModeName(string modeName) {
        switch (modeName) {
            case "Standard":
                return 1;
            case "OneSaber":
                return 2;
            case "NoArrows":
                return 3;
            case "90Degree":
                return 4;
            case "360Degree":
                return 5;
            case "Lightshow":
                return 6;
            case "Lawless":
                return 7;
        }

        return 0;
    }

    public static int DiffForDiffName(string diffName) {
        switch (diffName) {
            case "Easy":
            case "easy":
                return 1;
            case "Normal":
            case "normal":
                return 3;
            case "Hard":
            case "hard":
                return 5;
            case "Expert":
            case "expert":
                return 7;
            case "ExpertPlus":
            case "expertPlus":
                return 9;
        }

        return 0;
    }

    public static string DiffNameForDiff(int diff) {
        switch (diff) {
            case 1:
                return "Easy";
            case 3:
                return "Normal";
            case 5:
                return "Hard";
            case 7:
                return "Expert";
            case 9:
                return "ExpertPlus";
        }

        return "";
    }
}