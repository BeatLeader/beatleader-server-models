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
    public required string Id { get; set; }
    public required string Hash { get; set; }
    public required string Name { get; set; }
    [JsonIgnore]
    public string? Description { get; set; }
    public string? SubName { get; set; }
    public required string Author { get; set; }
    public required string Mapper { get; set; }
    public int MapperId { get; set; }
    public string? CollaboratorIds { get; set; }
    public required string CoverImage { get; set; }
    public string? FullCoverImage { get; set; }
    public required string DownloadUrl { get; set; }
    public double Bpm { get; set; }
    public double Duration { get; set; }
    public string? Tags { get; set; }

    [JsonIgnore]
    public string CreatedTime { get; set; } = "";
    public int UploadTime { get; set; }
    public required ICollection<DifficultyDescription> Difficulties { get; set; }
    public ICollection<ExternalStatus>? ExternalStatuses { get; set; }

    [JsonIgnore]
    public bool Checked { get; set; }
    [JsonIgnore]
    public bool Refreshed { get; set; }

    [JsonIgnore]
    public required ICollection<SongSearch> Searches { get; set; }

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

    public static int ModeForModeName(string modeName)
        => modeName switch {
            "Standard" => 1,
            "OneSaber" => 2,
            "NoArrows" => 3,
            "90Degree" => 4,
            "360Degree" => 5,
            "Lightshow" => 6,
            "Lawless" => 7,
            _ => 0
        };


    public static int DiffForDiffName(string diffName)
        => diffName switch {
            "Easy" => 1,
            "easy" => 1,
            "Normal" => 3,
            "normal" => 3,
            "Hard" => 5,
            "hard" => 5,
            "Expert" => 7,
            "expert" => 7,
            "ExpertPlus" => 9,
            "expertPlus" => 9,
            _ => 0
        };

    public static string DiffNameForDiff(int diff)
        => diff switch {
            1 => "Easy",
            3 => "Normal",
            5 => "Hard",
            7 => "Expert",
            9 => "ExpertPlus",
            _ => ""
        };
}