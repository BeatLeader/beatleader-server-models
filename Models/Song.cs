using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace BeatLeader_Server.Models
{
    [Flags]
    public enum SongStatus
    {
        None = 0,
        Curated = 1 << 1,
        MapOfTheWeek = 1 << 2,
        NoodleMonday = 1 << 3,
        FeaturedOnCC = 1 << 4,
        BeastSaberAwarded = 1 << 5,
        BuildingBlocksAwarded = 1 << 6
    }

    [Flags]
    public enum SongExplicitStatus
    {
        None = 0,
        Cover = 1 << 1,
        Lyrics = 1 << 2,
        Name = 1 << 3,
        Author = 1 << 4,
        Map = 1 << 5
    }

    public enum SongCreator
    {
        Human = 0,
        GenericBot = 1,
        BeatSage = 2,
        TopMapper = 3,

    }

    public class ExternalStatus
    {
        public int Id { get; set; }
        public SongStatus Status { get; set; }
        public int Timeset { get; set; }
        public string? Link { get; set; }
        public string? Responsible { get; set; }
        public string? Details { get; set; }
        public string? Title { get; set; }
        public string? TitleColor { get; set; }
    }

    [Index(nameof(Hash), IsUnique = true)]
    [Index(nameof(UploadTime), IsUnique = false)]
    public class Song : StringTrackedEntity
    {
        public string Id { get; set; }
        public string Hash { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public string? Description { get; set; }
        public string? SubName { get; set; }
        public string Author { get; set; }
        public string Mapper { get; set; }
        public ICollection<Mapper>? Mappers { get; set; }
        public int MapperId { get; set; }
        public string? CollaboratorIds { get; set; }
        public string CoverImage { get; set; }
        public string? FullCoverImage { get; set; }
        public string DownloadUrl { get; set; }
        public double Bpm { get; set; }
        public double Duration { get; set; }
        public string? Tags { get; set; }
        public SongCreator MapCreator { get; set; }
        public int UploadTime { get; set; }
        public SongStatus Status { get; set; }
        public SongExplicitStatus Explicity { get; set; }
        public ICollection<DifficultyDescription> Difficulties { get; set; }
        public ICollection<Leaderboard> Leaderboards { get; set; }
        public ICollection<ExternalStatus>? ExternalStatuses { get; set; }
        public string? VideoPreviewUrl { get; set; }

        [JsonIgnore]
        public bool Checked { get; set; }
        [JsonIgnore]
        public bool Refreshed { get; set; }

        [JsonIgnore]
        public ICollection<SongSearch> Searches { get; set; }

        public static SongCreator BotName(string mapper, string? declaredAi) {
            SongCreator result = SongCreator.GenericBot;
            if (declaredAi != null) {
                if (declaredAi.ToLower().Contains("sage")) {
                    result = SongCreator.BeatSage;
                }
                if (declaredAi.ToLower().Contains("topmapper")) {
                    result = SongCreator.TopMapper;
                }
            }

            if (result == SongCreator.GenericBot) {
                if (mapper.ToLower().Contains("sage")) {
                    result = SongCreator.BeatSage;
                }
                if (mapper.ToLower().Contains("topmapper")) {
                    result = SongCreator.BeatSage;
                }
            }
            return result;
        }

        public void FromMapDetails(MapDetail info)
        {
            Author = info.Metadata.SongAuthorName;
            Mapper = info.Metadata.LevelAuthorName;
            Name = info.Metadata.SongName;
            SubName = info.Metadata.SongSubName;
            Duration = info.Metadata.Duration;
            Bpm = info.Metadata.Bpm;
            MapperId = info.Uploader.Id;
            UploadTime = (int)info.Uploaded?.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            if (info.Tags != null)
            {
                Tags = string.Join(",", info.Tags);
            }
            if (info.Curator != null)
            {

                ExternalStatuses = new List<ExternalStatus>() {
                    new ExternalStatus {
                        Status = SongStatus.Curated,
                        Timeset = (int)info.CuratedAt?.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                        Responsible = "" + info.Curator.Id,
                    }
                };
            }

            if (info.Collaborators?.Count > 0)
            {
                CollaboratorIds = string.Join(",", info.Collaborators.Select(c => c.Id));
            }

            if (info.Automapper) {
                MapCreator = BotName(Mapper, info.DeclatedAi);
            }

            var currentVersion = info.Versions[0];
            CoverImage = currentVersion.CoverURL;
            DownloadUrl = currentVersion.DownloadURL;
            Hash = currentVersion.Hash;

            Explicity = info.Nsfw ? SongExplicitStatus.Cover : SongExplicitStatus.None;
            
            if (info.Id != null)
            {
                Id = info.Id;
            } else
            {
                Id = currentVersion.Key;
            }

            if (Explicity.HasFlag(SongExplicitStatus.Cover)) {
                CoverImage = System.Text.RegularExpressions.Regex.Replace(
                    CoverImage, 
                    @"https?://(?:[a-z]{2}\.)?cdn\.beatsaver\.com/",
                    $"https://api.beatleader.com/cover/processed/{Id}/"
                );
            }

            List<DifficultyDescription> difficulties = new List<DifficultyDescription>();
            var diffs = currentVersion.Diffs;
            foreach (var diff in diffs)
            {
                DifficultyDescription difficulty = new DifficultyDescription();
                difficulty.ModeName = diff.Characteristic;
                difficulty.Mode = ModeForModeName(diff.Characteristic);
                difficulty.DifficultyName = diff.Difficulty;
                difficulty.Value = DiffForDiffName(diff.Difficulty);
                difficulty.Hash = Hash;

                difficulty.Njs = diff.Njs;
                difficulty.Notes = diff.Notes;
                difficulty.Bombs = diff.Bombs;
                difficulty.Nps = diff.Nps;
                difficulty.Walls = diff.Obstacles;
                difficulty.MaxScore = diff.MaxScore;
                difficulty.Duration = info.Metadata.Duration;
                if (diff.Chroma)
                {
                    difficulty.Requirements |= Requirements.Chroma;
                    difficulty.RequiresChroma = true;
                }
                if (diff.Me)
                {
                    difficulty.Requirements |= Requirements.MappingExtensions;
                    difficulty.RequiresMappingExtensions = true;
                }
                if (diff.Ne)
                {
                    difficulty.Requirements |= Requirements.Noodles;
                    difficulty.RequiresNoodles = true;
                }
                if (diff.Cinema)
                {
                    difficulty.Requirements |= Requirements.Cinema;
                    difficulty.RequiresCinema = true;
                }

                difficulties.Add(difficulty);
            }
            Difficulties = difficulties;
        }

        public static int ModeForModeName(string modeName)
        {
            switch (modeName)
            {
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

        public static int DiffForDiffName(string diffName)
        {
            switch (diffName)
            {
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

        public static string DiffNameForDiff(int diff)
        {
            switch (diff)
            {
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
}
